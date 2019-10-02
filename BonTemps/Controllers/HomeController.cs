using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BonTemps.Models;
using BonTemps.Data;
using Microsoft.AspNetCore.Identity;

namespace BonTemps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Klant> _usermanager;
        private readonly SignInManager<Klant> _signmanager;

        public HomeController(ApplicationDbContext context, UserManager<Klant> userManager, SignInManager<Klant> signInManager)
        {
            _context = context;
            _usermanager = userManager;
            _signmanager = signInManager;
        }
        public IActionResult Index()
        {
            Sys.CheckAccount(_context, _usermanager, _signmanager, User.Identity.Name).Wait();
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
