using Microsoft.AspNetCore.Mvc;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepo;
        public ActorController(IActorRepository actorRepo)
        {
            this._actorRepo = actorRepo;
        }
        public IActionResult Index()
        {
            var model = _actorRepo.GetActors();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                Actor newactor = _actorRepo.AddActor(actor);
                return RedirectToAction("details", new { id = newactor.Id });
            }
            return View();
        }

        public ViewResult Details(int Id)
        {
            Actor actor = _actorRepo.GetActor(Id);
            if (actor == null)
            {
                Response.StatusCode = 404;
                return View("ActorNotFound", Id);
            }
            return View(actor);
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Actor actor = _actorRepo.GetActor(Id);
            return View(actor);
        }

        [HttpPost]
        public IActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                Actor actor = _actorRepo.GetActor(model.Id);
                actor.Name = model.Name;
                actor.Age = model.Age;
                Actor updatedActor = _actorRepo.UpdateActor(actor);
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Actor actor = _actorRepo.GetActor(Id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var actor = _actorRepo.GetActor(Id);
            _actorRepo.DeleteActor(actor.Id);

            return RedirectToAction("index");
        }
    }
}
