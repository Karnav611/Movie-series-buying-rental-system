using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class MovieImageController : Controller
    {
        private readonly IMovieImageRepository _movieimageRepo;
        private readonly IMovieRepository _movieRepo;
        private readonly IWebHostEnvironment _env;
        public MovieImageController(IMovieImageRepository movieimageRepo, IMovieRepository movieRepo, IWebHostEnvironment env)
        {
            this._movieimageRepo = movieimageRepo;
            this._env = env;
            this._movieRepo = movieRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            var movies = _movieimageRepo.GetMovies();
            ViewData["MovieId"] = new SelectList(movies, "Id", "Title");
            return View();
        }

        public IActionResult MovieImages(int Id)
        {
            var movie = _movieRepo.GetMovie(Id);
            ViewBag.Movie = movie;
            var model = _movieimageRepo.GetMovieImages(Id);
            IEnumerable<MovieImage> movieimages = _movieimageRepo.GetMovieImages(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieImage movieimage)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _env.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(movieimage.ImageFile.FileName);
                string extension = Path.GetExtension(movieimage.ImageFile.FileName);
                string Image = filename + extension;
                string path = Path.Combine(wwwrootpath + "/Images/Movies/", Image);
                movieimage.Path = "/Images/Movies/" + Image;
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await movieimage.ImageFile.CopyToAsync(filestream);
                }
                MovieImage newmovieimage = _movieimageRepo.AddMovieImage(movieimage);
                return RedirectToAction("details", new { id = newmovieimage.Id });
            }
            return View();
        }
        public ViewResult Details(int Id)
        {
            MovieImage movieimage = _movieimageRepo.GetImage(Id);
            var movies = _movieimageRepo.GetMovies();
            ViewData["MovieId"] = new SelectList(movies, "Id", "Title");
            if (movieimage == null)
            {
                Response.StatusCode = 404;
                return View("MovieImageNotFound", Id);
            }
            return View(movieimage);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            MovieImage movieimage = _movieimageRepo.GetImage(Id);
            if (movieimage == null)
            {
                return NotFound();
            }
            return View(movieimage);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var movieimage = _movieimageRepo.GetImage(Id);
            _movieimageRepo.DeleteMovieImage(movieimage.Id);

            return RedirectToAction("index");
        }
    }
}
