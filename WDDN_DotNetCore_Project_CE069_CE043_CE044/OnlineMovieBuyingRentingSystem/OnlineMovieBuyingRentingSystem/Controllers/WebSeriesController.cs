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
    public class WebSeriesController : Controller
    {
        private readonly IWebSeriesRepository _webseriesRepo;
        private readonly IWebHostEnvironment _env;
        public WebSeriesController(IWebSeriesRepository webseriesRepo, IWebHostEnvironment env)
        {
            this._webseriesRepo = webseriesRepo;
            this._env = env;
        }
        public IActionResult Index()
        {
            var model = _webseriesRepo.GetAllWebSeriess();
            return View(model);
        }
        public ViewResult ViewWebSeriesCast(int id)
        {
            var model = _webseriesRepo.GetWebSeriesCast(id);
            WebSeries webseries = _webseriesRepo.GetWebSeries(id);
            ViewBag.WebSeriesTitle = webseries.Title;
            var webseriess = _webseriesRepo.GetAllWebSeriess();
            ViewData["webseries"] = new SelectList(webseriess, "Id", "Title");
            var actors = _webseriesRepo.GetActors();
            ViewData["actors"] = new SelectList(actors, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            var genres = _webseriesRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WebSeries webseries)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _env.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(webseries.ImageFile.FileName);
                string extension = Path.GetExtension(webseries.ImageFile.FileName);
                string Image = filename + extension;
                string path = Path.Combine(wwwrootpath + "/Images/WebSeries/", Image);
                webseries.Poster = "/Images/WebSeries/"+Image;
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await webseries.ImageFile.CopyToAsync(filestream);
                }
                string webseriesfilename = Path.GetFileNameWithoutExtension(webseries.WebSeriesFile.FileName);
                string webseriesextension = Path.GetExtension(webseries.WebSeriesFile.FileName);
                string File = webseriesfilename + webseriesextension;
                string filepath = Path.Combine(wwwrootpath + "/files/WebSeries/", File);
                webseries.WebSeriesFilePath = "/files/WebSeries/"+File;
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    await webseries.WebSeriesFile.CopyToAsync(filestream);
                }
                WebSeries newwebseries = _webseriesRepo.AddWebSeries(webseries);
                return RedirectToAction("details", new { id = newwebseries.Id });
            }
            return View();
        }
        public IActionResult WebSeriesCastCreate()
        {
            return RedirectToAction("Create", "WebSeriesCast");
        }
        public IActionResult WebSeriesCastDetails(int Id)
        {
            return RedirectToAction("Details", "WebSeriesCast", new { id = Id });
        }
        public IActionResult WebSeriesCastEdit(int Id)
        {
            return RedirectToAction("Edit", "WebSeriesCast", new { id = Id });
        }
        public IActionResult WebSeriesCastDelete(int Id)
        {
            return RedirectToAction("Delete", "WebSeriesCast", new { id = Id });
        }
        public IActionResult ViewWebSeriesImages(int Id)
        {
            return RedirectToAction("WebSeriesImages", "WebSeriesImage", new { id = Id });
        }

        public ViewResult Details(int Id)
        {
            WebSeries webseries = _webseriesRepo.GetWebSeries(Id);
            var genres = _webseriesRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return View("WebSeriesNotFound", Id);
            }
            var webseriescast = _webseriesRepo.GetWebSeriesCast(Id);
            ViewData["WebSeriesCast"] = new SelectList(webseriescast, "Id", "Title");
            return View(webseries);
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            WebSeries webseries = _webseriesRepo.GetWebSeries(Id);
            var genres = _webseriesRepo.GetGenres();
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            return View(webseries);
        }

        [HttpPost]
        public IActionResult Edit(WebSeries model)
        {
            if (ModelState.IsValid)
            {
                WebSeries webseries = _webseriesRepo.GetWebSeries(model.Id);
                webseries.Title = model.Title;
                webseries.Description = model.Description;
                webseries.Genre = model.Genre;
                webseries.IMDBRating = model.IMDBRating;
                webseries.Poster = model.Poster;
                webseries.TrailerLink = model.TrailerLink;
                webseries.RentLink = model.RentLink;
                webseries.WebSeriesFile = model.WebSeriesFile;
                webseries.PurchasePrice = model.PurchasePrice;
                webseries.RentPrice = model.RentPrice;
                WebSeries updatedWebSeries = _webseriesRepo.UpdateWebSeries(webseries);

                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            WebSeries webseries = _webseriesRepo.GetWebSeries(Id);
            if (webseries == null)
            {
                return NotFound();
            }
            return View(webseries);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var webseries = _webseriesRepo.GetWebSeries(Id);
            _webseriesRepo.DeleteWebSeries(webseries.Id);

            return RedirectToAction("index");
        }
    }
}
