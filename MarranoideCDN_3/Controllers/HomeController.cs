using MarranoideCDN_3.Application;
using MarranoideCDN_3.Models;
using MarranoideCDN_3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.Keys.Contains("IDaccount") && HttpContext.Request.Cookies.Keys.Contains("sessionToken"))
                if (RepoSessions.OnSession(HttpContext.Request.Cookies["sessionToken"], HttpContext.Request.Cookies["IDaccount"]))
                    ViewData["session"] = new Session() { IDAccount = HttpContext.Request.Cookies["IDaccount"], SessionToken = HttpContext.Request.Cookies["sessionToken"] };


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
