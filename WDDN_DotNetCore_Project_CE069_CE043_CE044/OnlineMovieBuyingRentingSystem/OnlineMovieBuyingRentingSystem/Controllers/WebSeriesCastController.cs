using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineWebSeriesBuyingRentingSystem.Controllers
{
    public class WebSeriesCastController : Controller
    {
        private readonly IWebSeriesCastRepository _webseriescastRepo;
        public WebSeriesCastController(IWebSeriesCastRepository webseriescastRepo)
        {
            this._webseriescastRepo = webseriescastRepo;
        }
        public IActionResult Index()
        {
            var model = _webseriescastRepo.GetAllWebSeriesCast();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            var webseriess = _webseriescastRepo.GetWebSeriess();
            var actors = _webseriescastRepo.GetActors();
            ViewData["WebSeriesId"] = new SelectList(webseriess, "Id", "Title");
            ViewData["ActorId"] = new SelectList(actors, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(WebSeriesCast webseriescast)
        {
            if (ModelState.IsValid)
            {
                WebSeriesCast newwebseriescast = _webseriescastRepo.AddWebSeriesCast(webseriescast);
                return RedirectToAction("details", new { id = newwebseriescast.Id });
            }
            return View();
        }

        public ViewResult Details(int Id)
        {
            WebSeriesCast webseriescast = _webseriescastRepo.GetWebSeriesCast(Id);
            if (webseriescast == null)
            {
                Response.StatusCode = 404;
                //return NotFound();
                return View("WebSeriesCastNotFound", Id);
            }
            //var webseries = _webseriescastRepo.GetWebSeriesCast(WebSeriesCastId);
            //ViewData["webseries"] = new SelectList(webseries, "Id", "Title");
            var webseriess = _webseriescastRepo.GetWebSeriess();
            var actors = _webseriescastRepo.GetActors();
            ViewData["webseries"] = new SelectList(webseriess, "Id", "Title");
            ViewData["actors"] = new SelectList(actors, "Id", "Name");
            return View(webseriescast);
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            WebSeriesCast webseriescast = _webseriescastRepo.GetWebSeriesCast(Id);
            var webseriess = _webseriescastRepo.GetWebSeriess();
            var actors = _webseriescastRepo.GetActors();
            ViewData["WebSeriesId"] = new SelectList(webseriess, "Id", "Title");
            ViewData["ActorId"] = new SelectList(actors, "Id", "Name");
            return View(webseriescast);
        }

        [HttpPost]
        public IActionResult Edit(WebSeriesCast model)
        {
            if (ModelState.IsValid)
            {
                WebSeriesCast webseriescast = _webseriescastRepo.GetWebSeriesCast(model.Id);
                webseriescast.WebSeries = model.WebSeries;
                webseriescast.CharacterName = model.CharacterName;
                webseriescast.Actor = model.Actor;
                WebSeriesCast updatedWebSeriesCast = _webseriescastRepo.UpdateWebSeriesCast(webseriescast);
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            WebSeriesCast webseriescast = _webseriescastRepo.GetWebSeriesCast(Id);
            if (webseriescast == null)
            {
                return NotFound();
            }
            return View(webseriescast);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var webseriescast = _webseriescastRepo.GetWebSeriesCast(Id);
            _webseriescastRepo.DeleteWebSeriesCast(webseriescast.Id);

            return RedirectToAction("index");
        }
    }
}
