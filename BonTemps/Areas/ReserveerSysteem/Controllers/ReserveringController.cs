using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.ReserveerSysteem.Models;
using BonTemps.Data;

namespace BonTemps.Areas.ReserveerSysteem.Controllers
{
    [Area("ReserveerSysteem")]
    public class ReserveringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReserveringController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReserveerSysteem/Reservering
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservering.ToListAsync());
        }

        // GET: ReserveerSysteem/Reservering/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering
                .FirstOrDefaultAsync(m => m.ReserveringId == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: ReserveerSysteem/Reservering/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReserveerSysteem/Reservering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveringId,Voornaam,Toevoeging,Achternaam,Telefoonnummer,MobielNummer,AantalPersonen,ReserveeringsDatum")] Reservering reservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservering);
        }

        // GET: ReserveerSysteem/Reservering/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            return View(reservering);
        }

        // POST: ReserveerSysteem/Reservering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveringId,Voornaam,Toevoeging,Achternaam,Telefoonnummer,MobielNummer,AantalPersonen,ReserveeringsDatum")] Reservering reservering)
        {
            if (id != reservering.ReserveringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringExists(reservering.ReserveringId))
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
            return View(reservering);
        }

        // GET: ReserveerSysteem/Reservering/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering
                .FirstOrDefaultAsync(m => m.ReserveringId == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: ReserveerSysteem/Reservering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.Reservering.FindAsync(id);
            _context.Reservering.Remove(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveringExists(int id)
        {
            return _context.Reservering.Any(e => e.ReserveringId == id);
        }
    }
}
