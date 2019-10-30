using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Authorization;

namespace BonTemps.Areas.Chef.Controllers
{
    [Area("Chef")]
    [Authorize(Roles = "Chef,Manager")]
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
            var consumpties = _context.Consumpties.Include(c => c.Category).Include(a => a.ConsumptieAllergenen).ThenInclude(a => a.Allergenen);
            return View(await consumpties.ToListAsync());
        }

        // GET: Chef/Consumpties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptie = await _context.Consumpties
                .Include(c => c.Category).Include(x => x.ConsumptieAllergenen)
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
            ViewData["Allergenen"] = new SelectList(_context.Allergenen, "Id", "Beschrijving");
            return View();
        }

        // POST: Chef/Consumpties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int[]Allergenen, [Bind("Id,Naam,Beschrijving,Prijs,CategoryId,ConsAller")] Consumptie consumptie)
        //{


        //    List<ConsumptieAllergenen> UpdateList = new List<ConsumptieAllergenen>();
        //    foreach (var item in Allergenen)
        //    {
        //        ConsumptieAllergenen cons = new ConsumptieAllergenen();
        //        cons.AllergenenId = item;
        //        cons.ConsumptieId = consumptie.Id;
        //        Console.WriteLine("ALLERGEEN : " + cons.AllergenenId);
        //        UpdateList.Add(cons);
        //    }
        //    consumptie.ConsumptieAllergenen = UpdateList;

        //    //    [HttpPost]
        //    //[ValidateAntiForgeryToken]
        //    //public async Task<IActionResult> Create(int[] ConsumptieId, [Bind("Id,Menu_naam,Beschrijving,ConsumptieMenu")] Menu menu)
        //    //{
        //    //    Console.WriteLine("MENU ID : " + menu.Id);
        //    //    List<ConsumptieMenu> UpdateList = new List<ConsumptieMenu>();
        //    //    foreach (var item in ConsumptieId)
        //    //    {
        //    //        ConsumptieMenu cons = new ConsumptieMenu();
        //    //        cons.ConsumptieId = item;
        //    //        cons.MenuId = menu.Id;
        //    //        UpdateList.Add(cons);
        //    //    }

        //    //    menu.ConsumptieMenu = UpdateList;

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(consumptie);
        //        Console.WriteLine("MENU ID : " + consumptie.Id);

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //List<ConsumptieAllergenen> consall = new List<ConsumptieAllergenen>();
        //    //ConsumptieAllergenen test = new ConsumptieAllergenen();
        //    //test.Allergenen = _context.Allergenen.FirstOrDefault();
        //    //test.AllergenenId = test.Allergenen.Id;
        //    //test.Consumptie = _context.Consumpties.FirstOrDefault();
        //    //test.ConsumptieId = test.Consumptie.Id;

        //    //consall.Add(test);

        //    //consumptie.ConsAller = consall;

        //    //Console.WriteLine("\n\n HALLO ? ");
        //    //Console.WriteLine("\n\n Item : " + consumptie.ConsAller.Count + "\n\n");
        //    //ViewData["ConsAller"] = new SelectList(_context.Set<ConsumptieAllergenen>(), "Id", "Id", consumptie.ConsAller);
        //    //ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", consumptie.CategoryId);
        //    return View(consumptie);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int[] Allergenen, [Bind("Id,Naam,Beschrijving,Prijs,CategoryId")] Consumptie consumptie)
        {
            List<ConsumptieAllergenen> lijst = new List<ConsumptieAllergenen>();
            foreach (var item in Allergenen)
            {
                ConsumptieAllergenen Consaller = new ConsumptieAllergenen();
                Consaller.AllergenenId = item;
                Consaller.ConsumptieId = consumptie.Id;
                lijst.Add(Consaller);
            }

            consumptie.ConsumptieAllergenen = lijst;

            if (ModelState.IsValid)
            {
                _context.Add(consumptie);
                Console.WriteLine("MENU ID : " + consumptie.Id);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id", consumptieMenu.ConsumptieId);
            //ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", consumptieMenu.MenuId);
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
            ViewData["Menu_naam"] = new SelectList(_context.Menus, "Id", "Menu_naam");
            return View(consumptie);
        }

        // POST: Chef/Consumpties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Beschrijving,Prijs,CategoryId,MenuId")] Consumptie consumptie)
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
