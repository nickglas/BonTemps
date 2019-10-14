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
    public class AllergenenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllergenenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chef/Allergenen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Allergenen.ToListAsync());
        }

        // GET: Chef/Allergenen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergenen == null)
            {
                return NotFound();
            }

            return View(allergenen);
        }

        // GET: Chef/Allergenen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chef/Allergenen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Beschrijving,AllergenenIcoon")] Allergenen allergenen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergenen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergenen);
        }

        // GET: Chef/Allergenen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen.FindAsync(id);
            if (allergenen == null)
            {
                return NotFound();
            }
            return View(allergenen);
        }

        // POST: Chef/Allergenen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beschrijving,AllergenenIcoon")] Allergenen allergenen)
        {
            if (id != allergenen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergenen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergenenExists(allergenen.Id))
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
            return View(allergenen);
        }

        // GET: Chef/Allergenen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergenen == null)
            {
                return NotFound();
            }

            return View(allergenen);
        }

        // POST: Chef/Allergenen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergenen = await _context.Allergenen.FindAsync(id);
            _context.Allergenen.Remove(allergenen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergenenExists(int id)
        {
            return _context.Allergenen.Any(e => e.Id == id);
        }
    }
}
