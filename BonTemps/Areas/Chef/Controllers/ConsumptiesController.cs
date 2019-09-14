using System;
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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consumpties.Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chef/Consumpties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptie = await _context.Consumpties
                .Include(c => c.Category)
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
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Id", "Naam");
            return View();
        }

        // POST: Chef/Consumpties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Beschrijving,Prijs,CategoryId")] Consumptie consumptie)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!");
            Console.WriteLine(consumptie.CategoryId);
            if (ModelState.IsValid)
            {
                _context.Add(consumptie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", consumptie.CategoryId);
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
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Id", "Naam");
            return View(consumptie);
        }

        // POST: Chef/Consumpties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Beschrijving,Prijs,CategoryId")] Consumptie consumptie)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", consumptie.CategoryId);
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
                .Include(c => c.Category)
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
