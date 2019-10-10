using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeUI.Models;
using EmployeeManagementSystem;

namespace EmployeeUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["IsAdmin"] = HttpContext.User.Identity.Name == "jhon@gmail.com";
            ViewData["IsStandardUser"] = !string.IsNullOrEmpty(HttpContext.User.Identity.Name);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
