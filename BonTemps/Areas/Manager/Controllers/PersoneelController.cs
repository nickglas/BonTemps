using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonTemps.Areas.Manager.Controllers
{
    [Area("Manager")]

    public class PersoneelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersoneelController(ApplicationDbContext context) 
        {
            _context = context;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personeel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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