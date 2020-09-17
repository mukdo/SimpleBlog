using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Web.Models;
using Blog.Framework;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FrameworkContext _context;

        public HomeController(ILogger<HomeController> logger , FrameworkContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var post = _context.BlogComposes.OrderByDescending(d => d.Date);
            ViewBag.Post = post;
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
