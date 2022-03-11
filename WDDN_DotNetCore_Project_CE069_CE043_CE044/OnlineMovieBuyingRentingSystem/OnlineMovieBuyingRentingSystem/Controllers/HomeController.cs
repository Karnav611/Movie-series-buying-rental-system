using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepo;
        private readonly IMovieRepository _movieRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IHomeRepository homeRepo, IMovieRepository movieRepo, UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            _logger = logger;
            this._homeRepo = homeRepo;
            this._movieRepo = movieRepo;
        }

        public IActionResult Index()
        {
            var model = _homeRepo.GetMovies();
            ViewBag.Movies = model;
            ViewBag.WebSeries = _homeRepo.GetWebSeriess();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MoviesHomepage()
        {
            var model = _homeRepo.GetMovies();
            ViewBag.Movies = model;
            return View(model);
        }

        public IActionResult WebshowHomepage()
        {
            var model = _homeRepo.GetWebSeriess();
            ViewBag.WebSeries = _homeRepo.GetWebSeriess();
            return View(model);
        }

        public IActionResult PurchasePage(int Id)
        {
            Movie movie = _homeRepo.GetMovie(Id);
            var useremail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.MoviePurchased(Id, useremail);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return RedirectToAction("Download", new { id = Id });
            }
            return View(movie);
        }

        public IActionResult RentPage(int Id)
        {
            Movie movie = _homeRepo.GetMovie(Id);
            var useremail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.MovieRented(Id, useremail);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return RedirectToAction("OnlinePlayer", new { id = Id });
            }
            return View(movie);
        }

        public IActionResult MoviePage(int Id)
        {
            Movie movie = _homeRepo.GetMovie(Id);
            var genres = _homeRepo.GetGenres();
            var images = _homeRepo.GetImages(Id);
            ViewBag.Images = images;
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            if (movie == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            var cast = _homeRepo.GetCast(Id);
            ViewBag.Cast = cast;
            ViewData["Cast"] = new SelectList(cast, "Id", "Title");
            return View(movie);
        }

        public IActionResult Download(int Id)
        {
            Movie movie = _homeRepo.GetMovie(Id);
            var useremail = User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.MoviePurchased(Id, useremail);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return View(movie);
            }
            MoviePurchase moviePurchase = new MoviePurchase();
            moviePurchase.MovieId = Id;
            moviePurchase.UserEmail = useremail;
            _homeRepo.AddMoviePurchase(moviePurchase);
            return View(movie);
        }

        public IActionResult WebshowPage(int Id)
        {
            WebSeries webseries = _homeRepo.GetWebSeries(Id);
            var genres = _homeRepo.GetGenres();
            var images = _homeRepo.GetWebSeriesImages(Id);
            ViewBag.Images = images;
            ViewData["GenreId"] = new SelectList(genres, "Id", "Title");
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            var cast = _homeRepo.GetWebSeriesCast(Id);
            ViewBag.Cast = cast;
            ViewData["WebSeriesCast"] = new SelectList(cast, "Id", "Title");
            return View(webseries);
        }

        public IActionResult WebshowPurchasePage(int Id)
        {
            WebSeries webseries = _homeRepo.GetWebSeries(Id);
            var useremail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.WebSeriesPurchased(Id, useremail);
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return RedirectToAction("Download", new { id = Id });
            }
            return View(webseries);
        }

        public IActionResult OnlinePlayer(int Id)
        {
            Movie movie = _homeRepo.GetMovie(Id);
            var useremail = User.FindFirstValue(ClaimTypes.Email);
            var rented = _homeRepo.MovieRented(Id, useremail);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (rented)
            {
                return View(movie);
            }
            MovieRent movierent = new MovieRent();
            movierent.MovieId = Id;
            movierent.UserEmail = useremail;
            _homeRepo.AddMovieRent(movierent);
            return View(movie);
        }

        public IActionResult WebshowDownload(int Id)
        {
            WebSeries webseries = _homeRepo.GetWebSeries(Id);
            var useremail = User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.WebSeriesPurchased(Id, useremail);
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return View(webseries);
            }
            WebSeriesPurchase webseriesPurchase = new WebSeriesPurchase();
            webseriesPurchase.WebSeriesId = Id;
            webseriesPurchase.UserEmail = useremail;
            _homeRepo.AddWebSeriesPurchase(webseriesPurchase);
            return View(webseries);
        }

        public IActionResult WebshowRentPage(int Id)
        {
            WebSeries webseries = _homeRepo.GetWebSeries(Id);
            var useremail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var purchased = _homeRepo.WebSeriesRented(Id, useremail);
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (purchased)
            {
                return RedirectToAction("WebshowOnlinePlayer", new { id = Id });
            }
            return View(webseries);
        }

        public IActionResult WebshowOnlinePlayer(int Id)
        {
            WebSeries webseries = _homeRepo.GetWebSeries(Id);
            var useremail = User.FindFirstValue(ClaimTypes.Email);
            var rented = _homeRepo.WebSeriesRented(Id, useremail);
            if (webseries == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            if (rented)
            {
                return View(webseries);
            }
            WebSeriesRent webseriesrent = new WebSeriesRent();
            webseriesrent.WebSeriesId = Id;
            webseriesrent.UserEmail = useremail;
            _homeRepo.AddWebSeriesRent(webseriesrent);
            return View(webseries); 
        }
    }
}
