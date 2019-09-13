﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;

namespace BonTemps.Areas.Chef.Controllers
{
    [Area("Chef")]
    public class ConsumptiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumptiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chef/Consumpties
        public async Task<IActionResult> Index(string Id)
        {
            List < Consumptie > consumpties = new List<Consumptie>();
            string Categorie = Id;
            switch (Categorie)
            {
                case "Eten":
                    consumpties = await _context.Consumpties.Where(x => x.Id == Consumptie.Category_eten).ToListAsync();
                    ViewBag.Naam = Categorie;
                    return View(consumpties);
                    break;
                case "Deserts":
                    consumpties = await _context.Consumpties.Where(x => x.Id == Consumptie.Category_Deserts).ToListAsync();
                    ViewBag.Naam = Categorie;
                    return View(consumpties);
                    break;
                case "Drinken":
                    consumpties = await _context.Consumpties.Where(x => x.Id == Consumptie.Category_Drinken).ToListAsync();
                    ViewBag.Naam = Categorie;
                    return View(consumpties);
                    break;
                default:
                    consumpties = await _context.Consumpties.Where(x => x.Id == Consumptie.Category_eten).ToListAsync();
                    ViewBag.Naam = "Eten";
                    return View(consumpties);
                    break;
            }
        }
        // GET: Chef/Consumpties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptie = await _context.Consumpties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumptie == null)
            {
                return NotFound();
            }

            return View(consumptie);
        }

        // GET: Chef/Consumpties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chef/Consumpties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Beschrijving,Prijs")] Consumptie consumptie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumptie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumptie);
        }

        // GET: Chef/Consumpties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptie = await _context.Consumpties.FindAsync(id);
            if (consumptie == null)
            {
                return NotFound();
            }
            return View(consumptie);
        }

        // POST: Chef/Consumpties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Beschrijving,Prijs")] Consumptie consumptie)
        {
            if (id != consumptie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumptie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumptieExists(consumptie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consumptie);
        }

        // GET: Chef/Consumpties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptie = await _context.Consumpties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumptie == null)
            {
                return NotFound();
            }

            return View(consumptie);
        }

        // POST: Chef/Consumpties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumptie = await _context.Consumpties.FindAsync(id);
            _context.Consumpties.Remove(consumptie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumptieExists(int id)
        {
            return _context.Consumpties.Any(e => e.Id == id);
        }
    }
}