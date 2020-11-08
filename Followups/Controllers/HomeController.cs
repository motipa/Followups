using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Followups.Models;
using Microsoft.AspNetCore.Http;
using Followups.Models.DB;
using AutoMapper;

namespace Followups.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        public HomeController(ILogger<HomeController> logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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

        public IActionResult AddUser()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Title = "User";
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            using (var context = new FollowUpDbContext())
            {
               
                Employee employee = _mapper.Map<Employee>(userModel.Employee);
                User user = _mapper.Map<User>(userModel.User);

                context.Employee.Add(employee);
                context.SaveChanges();
                user.Empid = employee.Id;
                user.Username = employee.Email;
                user.IsActive = true;
                user.IsDelete = false;
                context.User.Add(user);
                context.SaveChanges();
               

               
            }
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
