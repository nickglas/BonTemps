using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BonTemps.Areas.Systeem.Controllers
{
    //[Authorize(Roles ="test")]
    [Area("Systeem")]

    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<Klant> _usermanager;
        private readonly SignInManager<Klant> _signmanager;

        public DashboardController(ApplicationDbContext context, UserManager<Klant> userManager, SignInManager<Klant> signInManager)
        {
            _context = context;
            _usermanager = userManager;
            _signmanager = signInManager;
        }

        public IActionResult Index()
        {
            Sys.CheckAccount(_context,_usermanager,_signmanager,User.Identity.Name).Wait();
            return View();
        }
    }
}