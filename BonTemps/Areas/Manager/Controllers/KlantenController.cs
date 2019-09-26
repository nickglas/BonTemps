using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonTemps.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class KlantenController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KlantenController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Klanten
        public ActionResult Index()
        {
            return View(_context.Klanten.Where(x=>x.Rolnaam == "Klant").ToList());
        }

        // GET: Klanten/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Klanten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klanten/Create
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

        // GET: Klanten/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Klanten/Edit/5
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

        // GET: Klanten/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Klanten/Delete/5
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