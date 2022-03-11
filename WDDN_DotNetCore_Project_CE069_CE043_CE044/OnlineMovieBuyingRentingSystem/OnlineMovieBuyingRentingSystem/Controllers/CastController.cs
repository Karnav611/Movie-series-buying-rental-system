using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastRepository _castRepo;
        public CastController(ICastRepository castRepo)
        {
            this._castRepo = castRepo;
        }
        public IActionResult Index()
        {
            var model = _castRepo.GetAllCast();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            var movies = _castRepo.GetMovies();
            var actors = _castRepo.GetActors();
            ViewData["MovieId"] = new SelectList(movies, "Id", "Title");
            ViewData["ActorId"] = new SelectList(actors, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cast cast)
        {
            if (ModelState.IsValid)
            {
                Cast newcast = _castRepo.AddCast(cast);
                return RedirectToAction("details", new { id = newcast.Id });
            }
            return View();
        }

        public ViewResult Details(int Id)
        {
            Cast cast = _castRepo.GetCast(Id);
            if (cast == null)
            {
                Response.StatusCode = 404;
                //return NotFound();
                return View("CastNotFound", Id);
            }
            //var movie = _castRepo.GetCast(CastId);
            //ViewData["movie"] = new SelectList(movie, "Id", "Title");
            var movies = _castRepo.GetMovies();
            var actors = _castRepo.GetActors();
            ViewData["movie"] = new SelectList(movies, "Id", "Title");
            ViewData["actors"] = new SelectList(actors, "Id", "Name");
            return View(cast);
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Cast cast = _castRepo.GetCast(Id);
            var movies = _castRepo.GetMovies();
            var actors = _castRepo.GetActors();
            ViewData["MovieId"] = new SelectList(movies, "Id", "Title");
            ViewData["ActorId"] = new SelectList(actors, "Id", "Name");
            return View(cast);
        }

        [HttpPost]
        public IActionResult Edit(Cast model)
        {
            if (ModelState.IsValid)
            {
                Cast cast = _castRepo.GetCast(model.Id);
                cast.Movie = model.Movie;
                cast.CharacterName = model.CharacterName;
                cast.Actor = model.Actor;
                Cast updatedCast = _castRepo.UpdateCast(cast);
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Cast cast = _castRepo.GetCast(Id);
            if (cast == null)
            {
                return NotFound();
            }
            return View(cast);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var cast = _castRepo.GetCast(Id);
            _castRepo.DeleteCast(cast.Id);

            return RedirectToAction("index");
        }
    }
}
