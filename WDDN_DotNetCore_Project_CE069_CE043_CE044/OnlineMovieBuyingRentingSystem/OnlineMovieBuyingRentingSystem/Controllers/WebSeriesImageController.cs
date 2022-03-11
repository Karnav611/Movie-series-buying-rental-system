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
    public class WebSeriesImageController : Controller
    {
        private readonly IWebSeriesImageRepository _webseriesimageRepo;
        private readonly IWebSeriesRepository _webseriesRepo;
        private readonly IWebHostEnvironment _env;
        public WebSeriesImageController(IWebSeriesImageRepository webseriesimageRepo, IWebSeriesRepository webseriesRepo, IWebHostEnvironment env)
        {
            this._webseriesimageRepo = webseriesimageRepo;
            this._env = env;
            this._webseriesRepo = webseriesRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            var webseriess = _webseriesimageRepo.GetWebSeriess();
            ViewData["WebSeriesId"] = new SelectList(webseriess, "Id", "Title");
            return View();
        }

        public IActionResult WebSeriesImages(int Id)
        {
            var webseries = _webseriesRepo.GetWebSeries(Id);
            ViewBag.WebSeries = webseries;
            var model = _webseriesimageRepo.GetWebSeriesImages(Id);
            //IEnumerable<MovieImage> movieimages = _webseriesimageRepo.GetImages(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WebSeriesImage webseriesimage)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _env.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(webseriesimage.WebSeriesImageFile.FileName);
                string extension = Path.GetExtension(webseriesimage.WebSeriesImageFile.FileName);
                string Image = filename + extension;
                string path = Path.Combine(wwwrootpath + "/Images/WebSeriess/", Image);
                webseriesimage.Path = "/Images/WebSeriess/" + Image;
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await webseriesimage.WebSeriesImageFile.CopyToAsync(filestream);
                }
                WebSeriesImage newwebseriesimage = _webseriesimageRepo.AddWebSeriesImage(webseriesimage);
                return RedirectToAction("details", new { id = newwebseriesimage.Id });
            }
            return View();
        }
        public ViewResult Details(int Id)
        {
            WebSeriesImage webseriesimage = _webseriesimageRepo.GetImage(Id);
            var webseriess = _webseriesimageRepo.GetWebSeriess();
            ViewData["WebSeriesId"] = new SelectList(webseriess, "Id", "Title");
            if (webseriesimage == null)
            {
                Response.StatusCode = 404;
                return View("WebSeriesImageNotFound", Id);
            }
            return View(webseriesimage);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            WebSeriesImage webseriesimage = _webseriesimageRepo.GetImage(Id);
            if (webseriesimage == null)
            {
                return NotFound();
            }
            return View(webseriesimage);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var webseriesimage = _webseriesimageRepo.GetImage(Id);
            _webseriesimageRepo.DeleteWebSeriesImage(webseriesimage.Id);

            return RedirectToAction("index");
        }
    }
}
