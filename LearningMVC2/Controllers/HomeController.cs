using LearningMVC2.Data;
using LearningMVC2.Models;
using LearningMVC2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pax = await context.Persons
                .Include(x => x.Adress)
                .Include(x => x.Pet)
                .ToListAsync();

            return View(pax);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevents calling Action outside website
        public IActionResult Create([Bind("FirstName, LastName, Street, " +
            "City, Type, Name")] PersonViewModel person)
        {
            var test = person; //for Debug with mouse over
            if(ModelState.IsValid)
            {
                
                Person pax = new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName
                };
                Adress adress = new Adress
                {
                    Street = person.Street,
                    City = person.Street
                };
                Pet pet = new Pet
                {
                    Type = person.Type,
                    Name = person.Name
                };
                context.Add(adress);
                context.Add(pet);
                context.SaveChanges(); //first save adress and pet to have the assigned id´s
                pax.AdressId = adress.Id;
                pax.PetId = pet.Id;
                context.Add(pax);
                context.SaveChanges(); //set the id´s and add pax and save to database
                return RedirectToAction("Index"); //redirect
            }


            return View(person);
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
