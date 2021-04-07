using DissapearPersonsRegistry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MissingPersonsRegistry.Data;
using MissingPersonsRegistry.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }

        [AllowAnonymous]
        public IActionResult Index(int id = 0)
        {
            var persons = homeService.Index(id);
            return View(persons);
        }
       

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            homeService.Create(person);
            return Redirect("Index");
        }
        [AllowAnonymous]
        public IActionResult Details(int id) 
        {
            var person = homeService.GetDetails(id);
            return View(person);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int id) 
        {
            var person = homeService.GetDetails(id);
            return View(person);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Home/Edit");
            }
            homeService.Edit(person);
            return RedirectToAction("Details", "Home", new { person.Id });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) 
        {
            var person = homeService.GetDetails(id);

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult ConfirmDelete(int id)
        {
            homeService.ConfirmDelete(id);
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
