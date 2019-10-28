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
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get; set; }

        // GET: Chef/Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.ToListAsync());
        }

        // GET: Chef/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var menu = await _context.Menus
                .Include(c => c.ConsumptieMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Chef/Menu/Create
        public IActionResult Create()
        {
            ViewData["TafelsId"] = new SelectList(_context.Tafels.Where(x => x.Bezet == true), "Id", "Id");
            ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Naam");
            ViewData["Voorgerecht"] = new SelectList(_context.Consumpties.Where(x => x.CategoryId == 1), "Id", "Naam");
            ViewData["Hoofdgerecht"] = new SelectList(_context.Consumpties.Where(x => x.CategoryId == 4), "Id", "Naam");
            ViewData["Nagerecht"] = new SelectList(_context.Consumpties.Where(x => x.CategoryId == 3), "Id", "Naam");
            ViewData["Drinken"] = new SelectList(_context.Consumpties.Where(x => x.CategoryId == 2), "Id", "Naam");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Naam");

            return View();
        }

        // POST: Chef/Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int[] ConsumptieId,[Bind("Id,Menu_naam,Beschrijving,ConsumptieMenu")] Menu menu)
        {
            List<ConsumptieMenu> UpdateList = new List<ConsumptieMenu>();
            foreach (var item in ConsumptieId)
            {
                ConsumptieMenu cons = new ConsumptieMenu();
                cons.ConsumptieId = item;
                cons.MenuId = menu.Id;
                UpdateList.Add(cons);
            }

            menu.ConsumptieMenu = UpdateList;

            //List<ConsumptieMenu> list = new List<ConsumptieMenu>();

            //ConsumptieMenu iets = new ConsumptieMenu();
            //iets.ConsumptieId = 2;
            //iets.MenuId = menu.Id;
            //list.Add(iets);

            //ConsumptieMenu test = new ConsumptieMenu();
            //test.ConsumptieId = 1;
            //test.MenuId = menu.Id;
            //list.Add(test);

            //ConsumptieMenu iets2 = new ConsumptieMenu();
            //iets.ConsumptieId = 2;
            //iets.MenuId = 1;
            //list.Add(iets2);

            //ConsumptieMenu iets3 = new ConsumptieMenu();
            //iets.ConsumptieId = 3;
            //iets.MenuId = 1;
            //list.Add(iets3);

            //menu.ConsumptieMenu = list;
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                Console.WriteLine("MENU ID : " + menu.Id);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ConsumptieId"] = new SelectList(_context.Consumpties, "Id", "Id", consumptieMenu.ConsumptieId);
            //ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", consumptieMenu.MenuId);
            return View(menu);
        }

        // GET: Chef/Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Chef/Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Menu_naam,Beschrijving")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }

        // GET: Chef/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Chef/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
