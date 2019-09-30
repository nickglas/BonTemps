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
    public class BestellingenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BestellingenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Systeem/Bestellingen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bestellingen.Include(b => b.Consumptie)
                                                            .Include(a => a.Consumptie.Category)
                                                            .Include(b => b.Tafels)
                                                            .Where(x => x.Afgerond == false);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Systeem/Bestellingen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.Bestellingen
                .Include(b => b.Consumptie)
                .Include(b => b.Tafels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestelling == null)
            {
                return NotFound();
            }

            return View(bestelling);
        }

        public async Task<IActionResult> Archiveren(int? Id)
        {

            Console.WriteLine("\n!!Iets van text!!\n");
            Bestelling res = await _context.Bestellingen.Where(x => x.Id == Id).FirstOrDefaultAsync();
            BestellingArchief archief = new BestellingArchief
            {
                TafelsId = res.TafelsId,
                Bestellingsdatum_afgerond = res.Bestellingsdatum_afgerond,
                Bestellingsdatum_Tijd = res.Bestellingsdatum_Tijd,
                Consumptie = _context.Consumpties.Where(x=>x.Id == res.Id).FirstOrDefault().Naam,
                Archiveerdatum = DateTime.Now
            };

            await _context.BestellingArchief.AddAsync(archief);
            await _context.SaveChangesAsync();
            _context.Bestellingen.Remove(res);
            await _context.SaveChangesAsync();

            return RedirectToAction("AfgerondeBestellingen");
        }

        public async Task<IActionResult> DeleteArchief_All()
        {
            List<BestellingArchief> archief = await _context.BestellingArchief.ToListAsync();
            _context.BestellingArchief.RemoveRange(archief);
            await _context.SaveChangesAsync();
            return RedirectToAction("Archief");
        }


        public async Task<IActionResult> Archief()
        {
            return View(await _context.BestellingArchief.ToListAsync());
        }

        // GET: Systeem/Bestellingen/Create
        public IActionResult Create()
        {
            ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id");
            ViewData["TafelsId"] = new SelectList(_context.Tafels.Where(x=> x.Bezet == true), "Id", "Id");
            ViewData["Consumptienaam"] = new SelectList(_context.Consumpties, "Id", "Naam");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Naam");

            return View();
        }

        // POST: Systeem/Bestellingen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsumptieId,TafelsId,Bestellingsdatum_Tijd,Afgerond")] Bestelling bestelling)
        {
            bestelling.Bestellingsdatum_Tijd = DateTime.Now;
            bestelling.Afgerond = false;
            if (ModelState.IsValid)
            {
                _context.Add(bestelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id", bestelling.ConsumptieId);
            ViewData["TafelsId"] = new SelectList(_context.Tafels, "Id", "Id", bestelling.TafelsId);
            return View(bestelling);
        }

        // GET: Systeem/Bestellingen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.Bestellingen.FindAsync(id);
            if (bestelling == null)
            {
                return NotFound();
            }
            ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id", bestelling.ConsumptieId);
            ViewData["TafelsId"] = new SelectList(_context.Tafels, "Id", "Id", bestelling.TafelsId);
            return View(bestelling);
        }

        // POST: Systeem/Bestellingen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsumptieId,TafelsId,Bestellingsdatum_Tijd,Afgerond")] Bestelling bestelling)
        {
            if (id != bestelling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestellingExists(bestelling.Id))
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
            ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id", bestelling.ConsumptieId);
            ViewData["TafelsId"] = new SelectList(_context.Tafels, "Id", "Id", bestelling.TafelsId);
            return View(bestelling);
        }

        // GET: Systeem/Bestellingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.Bestellingen
                .Include(b => b.Consumptie)
                .Include(b => b.Tafels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestelling == null)
            {
                return NotFound();
            }

            return View(bestelling);
        }

        // POST: Systeem/Bestellingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestelling = await _context.Bestellingen.FindAsync(id);
            _context.Bestellingen.Remove(bestelling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestellingExists(int id)
        {
            return _context.Bestellingen.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Afronden(int id)
        {
            Bestelling bestelling = _context.Bestellingen.Where(x => x.Id == id).FirstOrDefault();
            bestelling.Afgerond = true;
            bestelling.Bestellingsdatum_afgerond = DateTime.Now;
            _context.Bestellingen.Update(bestelling);
            await _context.SaveChangesAsync();
            return  RedirectToAction("Index");
        }
        
        public async Task<IActionResult> AfgerondeBestellingen()
        {
            var applicationDbContext = _context.Bestellingen.Include(b => b.Consumptie).Include(b => b.Tafels).Where(x => x.Afgerond == true);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
