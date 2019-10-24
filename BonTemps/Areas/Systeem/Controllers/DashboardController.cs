using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Areas.Systeem.Models;
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

            //Alle specifieke item voor de gepaste rol
            Dashboard dash = new Dashboard();
            if (User.IsInRole("Manager"))
            {
                dash.users = _context.Klanten.Where(x=>x.Rol.Name=="Klant").ToList();
                dash.Reserveringen = _context.Reserveringen.Where(x => x.ReserveringsDatum == DateTime.Today).ToList();
                dash.Tafels = _context.Tafels.Where(x => x.Bezet == false).ToList();
                //Omzet berekenen door afgeronden bestellingen en archief
                double Omzet = 0.0;
                List<Bestelling> bestellingen = _context.Bestellingen.Where(x => x.Afgerond == true).ToList();
                List<BestellingArchief> archief = _context.BestellingArchief.ToList();

                Console.WriteLine("\n\nItem count in bestelling afgerond : " + bestellingen.Count);
                Console.WriteLine("\n\nItem count in archief  : " + archief.Count);

                foreach (var item in bestellingen)
                {
                    Console.WriteLine("!! \n\nItems in bestelling : " + item.Aantal);
                    Consumptie cons = _context.Consumpties.Where(x => x.Id == item.ConsumptieId).First();

                    Omzet += cons.Prijs * item.Aantal;
                }
                foreach (var item in archief)
                {
                    Omzet += _context.Consumpties.Where(x => x.Naam == item.Consumptie).First().Prijs * item.Aantal;
                }
                dash.Omzet = Omzet;
            }
            
            return View(dash);
        }
    }
}