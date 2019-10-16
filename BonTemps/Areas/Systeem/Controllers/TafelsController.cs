using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;

namespace BonTemps.Areas.Systeem.Controllers
{
    [Area("Systeem")]
    public class TafelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TafelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Systeem/Tafels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tafels.ToListAsync());
        }

        // GET: Systeem/Tafels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafels = await _context.Tafels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tafels == null)
            {
                return NotFound();
            }

            return View(tafels);
        }

        public async Task<IActionResult> Afrekenen(int id)
        {
            double TotaalPrijs = 0;
            Tafels tafel = await _context.Tafels.Where(x => x.Id == id).FirstOrDefaultAsync();
            List<Bestelling> bestellingen = await _context.Bestellingen.Where(x => x.TafelsId == id && x.Afgerond == true).ToListAsync();
            foreach (var item in bestellingen)
            {
                TotaalPrijs += _context.Consumpties.Where(x => x.Id == item.ConsumptieId).FirstOrDefault().Prijs;
                BestellingArchief archief = new BestellingArchief
                {
                    TafelsId = item.TafelsId,
                    Consumptie = item.Consumptie.Naam,
                    Archiveerdatum = DateTime.Now,
                    Bestellingsdatum_afgerond = item.Bestellingsdatum_afgerond,
                    Bestellingsdatum_Tijd = item.Bestellingsdatum_Tijd,
                };
                await _context.BestellingArchief.AddAsync(archief);
                Console.WriteLine(item.Consumptie.Naam);
            }
            _context.RemoveRange(bestellingen);
            tafel.Bezet = false;
            _context.Tafels.Update(tafel);
            await _context.SaveChangesAsync();

            Console.WriteLine(TotaalPrijs);
            return RedirectToAction("Index");
        }

        // GET: Systeem/Tafels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Systeem/Tafels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zitplaatsen,Bezet")] Tafels tafels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tafels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tafels);
        }

        // GET: Systeem/Tafels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafels = await _context.Tafels.FindAsync(id);
            if (tafels == null)
            {
                return NotFound();
            }
            return View(tafels);
        }

        // POST: Systeem/Tafels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zitplaatsen,Bezet")] Tafels tafels)
        {
            if (id != tafels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tafels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TafelsExists(tafels.Id))
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
            return View(tafels);
        }

        // GET: Systeem/Tafels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafels = await _context.Tafels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tafels == null)
            {
                return NotFound();
            }

            return View(tafels);
        }

        // POST: Systeem/Tafels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tafels = await _context.Tafels.FindAsync(id);
            _context.Tafels.Remove(tafels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TafelsExists(int id)
        {
            return _context.Tafels.Any(e => e.Id == id);
        }
    }
}
