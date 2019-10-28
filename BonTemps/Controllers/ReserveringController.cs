using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BonTemps.Controllers
{
    public class ReserveringController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public ReserveringController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        // GET: Reservering
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reserveringen.ToListAsync());
        }

        // GET: Reservering/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: Reservering/Create
        public IActionResult Create()
        {
            string ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            Console.WriteLine(ip);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Reservering()
        {
            List<Reservering> reserveringen = await _context.Reserveringen.Where(x => x.Email == User.Identity.Name).ToListAsync();
            return View(reserveringen);
        }

        // POST: Reservering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithEmail([Bind("Id,NaamReserveerder,Email,HuisTelefoonNummer,MobielTelefoonNummer,AantalPersonen,Opmerking,ReserveringsDatum")] Reservering reservering)
        {
            reservering.Goedkeuring = false;
            reservering.ReserveringAangemaakt = DateTime.Now;
            

            _context.Reserveringen.Add(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Reservering");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithUser([Bind("Id,NaamReserveerder,Email,HuisTelefoonNummer,MobielTelefoonNummer,AantalPersonen,Goedkeuring,Opmerking,ReserveringsDatum,ReserveringAangemaakt")] Reservering reservering)
        {
            
            reservering.Email = User.Identity.Name;
            Klant res = _context.Klanten.Where(x => x.Email == reservering.Email).Include(x=> x.Klantgegevens).FirstOrDefault();
            reservering.NaamReserveerder = res.Klantgegevens.Achternaam;
            Console.WriteLine("CREATED WITH ACHTERNAAM : " + res.Klantgegevens.Achternaam);
            reservering.Goedkeuring = false;
            reservering.ReserveringAangemaakt = DateTime.Now;

            _context.Reserveringen.Add(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Reservering");
        }

        // GET: Reservering/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            return View(reservering);
        }

        // POST: Reservering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NaamReserveerder,Email,HuisTelefoonNummer,MobielTelefoonNummer,AantalPersonen,Goedkeuring,Opmerking,ReserveringsDatum,ReserveringAangemaakt")] Reservering reservering)
        {
            if (id != reservering.Id)
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
                    if (!ReserveringExists(reservering.Id))
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

        // GET: Reservering/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: Reservering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.Reserveringen.FindAsync(id);
            _context.Reserveringen.Remove(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveringExists(int id)
        {
            return _context.Reserveringen.Any(e => e.Id == id);
        }
    }
}
