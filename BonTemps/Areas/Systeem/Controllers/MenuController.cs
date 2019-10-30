using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BonTemps.Areas.Systeem.Controllers
{
    public class MenuController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = _context.Menus
            .Include(cm => cm.ConsumptieMenu).ThenInclude(c => c.Consumptie);
            return View(await menus.ToListAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            foreach (var filter in _context.Consumpties)
            {

            }
            var Menu = await _context.Menus
              .Include(cm => cm.ConsumptieMenu)
              .ThenInclude(c => c.Consumptie)
              .ThenInclude(ca => ca.ConsumptieAllergenen)
              .FirstOrDefaultAsync(m => m.Id == id);
            if (Menu == null)
            {
                return NotFound();
            }
            ViewBag.Menu = Menu.Menu_naam;
            return View(Menu);
        }
    }
}
