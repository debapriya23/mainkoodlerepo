using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthRoleBased.Models;
using Microsoft.AspNetCore.Authorization;
using KOODLE.Models;
using AuthRoleBased.Data;

namespace AuthRoleBased.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _ctx;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult posts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult edit()
        {
            return View(new posts());
        }

        [HttpPost]
        public async Task<IActionResult> editAsync(posts posts)
        {

            _ctx.posts.Add(posts);
           await _ctx.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
