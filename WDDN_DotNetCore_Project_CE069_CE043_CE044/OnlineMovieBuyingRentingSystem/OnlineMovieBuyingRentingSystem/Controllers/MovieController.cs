using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IWebHostEnvironment _env;
        public MovieController(IMovieRepository movieRepo, IWebHostEnvironment env)
        {
            this._movieRepo = movieRepo;
            this._env = env;
        }
        public IActionResult Index()
        {
            var model = _movieRepo.GetAllMovies();
            return View(model);
        }
        public ViewResult ViewCast(int id)
        {
            var model = _movieRepo.GetCast(id);
            Movie movie = _movieRepo.GetMovie(id);
            ViewBag.MovieTitle = movie.Title;
            var movies = _movieRepo.GetAllMovies();
            ViewData["movie"] = new SelectList(movies, "Id", "Title");
            var actors = _movieRepo.GetActors();
            ViewData["actors"] = new SelectList(actors, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            var genres = _movieRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _env.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                string extension = Path.GetExtension(movie.ImageFile.FileName);
                string Image = filename + extension;
                string path = Path.Combine(wwwrootpath + "/Images/Movies/", Image);
                movie.Poster = "/Images/Movies/"+Image;
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await movie.ImageFile.CopyToAsync(filestream);
                }
                string moviefilename = Path.GetFileNameWithoutExtension(movie.MovieFile.FileName);
                string movieextension = Path.GetExtension(movie.MovieFile.FileName);
                string File = moviefilename + movieextension;
                string filepath = Path.Combine(wwwrootpath + "/files/Movies/", File);
                movie.MovieFilePath = "/files/Movies/"+File;
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    await movie.MovieFile.CopyToAsync(filestream);
                }
                Movie newmovie = _movieRepo.AddMovie(movie);
                return RedirectToAction("details", new { id = newmovie.Id });
            }
            return View();
        }
        public IActionResult ViewImages(int Id)
        {
            return RedirectToAction("MovieImages", "MovieImage",new { id = Id});
        }
        public IActionResult CastCreate()
        {
            return RedirectToAction("Create", "Cast");
        }
        public IActionResult CastDetails(int Id)
        {
            return RedirectToAction("Details", "Cast", new { id = Id });
        }
        public IActionResult CastEdit(int Id)
        {
            return RedirectToAction("Edit", "Cast", new { id = Id });
        }
        public IActionResult CastDelete(int Id)
        {
            return RedirectToAction("Delete", "Cast", new { id = Id });
        }

        public ViewResult Details(int Id)
        {
            Movie movie = _movieRepo.GetMovie(Id);
            var genres = _movieRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            if (movie == null)
            {
                Response.StatusCode = 404;
                return View("MovieNotFound", Id);
            }
            var cast = _movieRepo.GetCast(Id);
            ViewData["Cast"] = new SelectList(cast, "Id", "Title");
            return View(movie);
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Movie movie = _movieRepo.GetMovie(Id);
            var genres = _movieRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                Movie movie = _movieRepo.GetMovie(model.Id);
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.Genre = model.Genre;
                movie.IMDBRating = model.IMDBRating;
                movie.Poster = model.Poster;
                movie.TrailerLink = model.TrailerLink;
                movie.RentLink = model.RentLink;
                movie.MovieFilePath = model.MovieFilePath;
                movie.PurchasePrice = model.PurchasePrice;
                movie.RentPrice = model.RentPrice;
                Movie updatedMovie = _movieRepo.UpdateMovie(movie);

                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Movie movie = _movieRepo.GetMovie(Id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var movie = _movieRepo.GetMovie(Id);
            _movieRepo.DeleteMovie(movie.Id);

            return RedirectToAction("index");
        }
    }
}
