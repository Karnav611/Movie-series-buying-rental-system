using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }
        public IActionResult Index()
        {
            var useremail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            if (useremail == null || useremail != "admin@gmail.com")
            {
                return Redirect("/Identity/Account/Login");
            }
            return View();
        }
    }
}
