using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;

namespace BonTemps.Areas.Systeem.Controllers
{
    [Area("Systeem")]
    public class TafelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public TafelsController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _env = environment;
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
            //Infotmatie ophalen
            double TotaalPrijs = 0;
            Tafels tafel = await _context.Tafels.Where(x => x.Id == id).FirstOrDefaultAsync();
            List<Bestelling> bestellingen = await _context.Bestellingen.Where(x => x.TafelsId == id && x.Afgerond == true).ToListAsync();
            
            //Bestellingen naar het archief plaatsen en totaalprijs berekenen
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

            //Database updaten
            _context.RemoveRange(bestellingen);
            tafel.Bezet = false;
            _context.Tafels.Update(tafel);
            await _context.SaveChangesAsync();


            ViewBag.totaal = TotaalPrijs;
            ViewBag.TafelId = tafel.Id;

            Console.WriteLine("TAFEL ID : " + tafel.Id);

            return new ViewAsPdf(bestellingen);

        }
        public async Task<IActionResult> StatusAanpassen(int id)
        {
            Tafels tafel = _context.Tafels.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine("Gekozen tafel = " + tafel);
            Console.WriteLine("Tafel is bezet = " + tafel.Bezet);
            if (tafel.Bezet == false)
            {
                tafel.Bezet = true;
            } else 
            {
                tafel.Bezet = false;
            }
            _context.Tafels.Update(tafel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Printbon(int Id)
        {
            //Console.WriteLine("TAFEL ID : " + Id);
            //Console.WriteLine("Folder : " + _env.ContentRootPath);
            FileStream fs = new FileStream(_env.ContentRootPath+"//PDF//"+"Bon"+"_Tafel_"+Id+".PDF" , FileMode.Create);
            return RedirectToAction("Index", "Tafels");
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
