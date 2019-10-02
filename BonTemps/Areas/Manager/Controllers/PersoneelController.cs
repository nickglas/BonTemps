using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BonTemps.Areas.Manager.Controllers
{
    [Area("Manager")]

    public class PersoneelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Klant> _userManager;
        public string user = "";
        public PersoneelController(ApplicationDbContext context, UserManager<Klant> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Personeel
        public ActionResult Index()
        {
            List<Klant> personeel = _context.Klanten.Where(x => x.Rolnaam != "Klant").ToList();
            return View(personeel);
        }



        // GET: Personeel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personeel/Create
        public ActionResult PersoneelAanmelden()
        {
            ViewData["CategoryName"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> DeleteUser(string Id)
        {
            Klant klant =  _context.Klanten.Where(x => x.Id == Id).FirstOrDefault();
            _context.Klanten.Remove(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PersoneelGegevens(string id)
        {
            ViewBag.user = id;
            return View();
        }

        public async Task<IActionResult> LinkGegevens(string id, [Bind("Id,Voornaam,Achternaam,GeboorteDatum,Geslacht,TelefoonNummer")] Klantgegevens gegevens)
        {
            
            Console.WriteLine("\n\n EMAAAILLLLL : " + id + "\n\n");
            Klant klant = _context.Klanten.Where(x => x.UserName == id).FirstOrDefault();
            klant.Klantgegevens = new Klantgegevens
            {
                Voornaam = gegevens.Voornaam,
                Achternaam = gegevens.Achternaam,
                GeboorteDatum = gegevens.GeboorteDatum,
                Geslacht = gegevens.Geslacht,
                TelefoonNummer = gegevens.TelefoonNummer
            };
            _context.Update(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // POST: Personeel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,PasswordHash,Rolnaam")] Klant klant)
        {
            klant.Aanmaakdatum = DateTime.Now;
            klant.UserName = klant.Email;

            Console.WriteLine("eerste Rol : " + klant.Rolnaam);


            string rol = _context.Roles.Where(x => x.Id == klant.Rolnaam).FirstOrDefault().Name;

            Console.WriteLine("\n!!! PERSONEEL !!!\n");
            Console.WriteLine("Username : " + klant.UserName);
            Console.WriteLine("Email : " + klant.Email);
            Console.WriteLine("Wachtwoord : " + klant.PasswordHash);
            Console.WriteLine("einde Rol : " + rol);
            klant.Rolnaam = rol;
            string pass = klant.PasswordHash;
            klant.PasswordHash = null;
            if (ModelState.IsValid)
            {

                var result = await _userManager.CreateAsync(klant);

                if (result.Succeeded)
                {
                    
                    await _userManager.AddPasswordAsync(klant, pass);
                    await _userManager.AddToRoleAsync(klant, rol);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("PersoneelGegevens", new { id = klant.UserName });



        }
    

        // GET: Personeel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personeel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personeel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personeel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
