using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Followups.Models;
using Microsoft.AspNetCore.Http;

namespace Followups.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()

        {
            
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Title = "Admin";
            return View();
        }
        public IActionResult User()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Title = "User";
            return View();
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
    }
}
