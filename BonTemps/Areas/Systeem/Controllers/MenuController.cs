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
            return View(await _context.Menus.ToListAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var menu = await _context.Menus
             .Include(c => c.Consumpties)
             .FirstOrDefaultAsync(m => m.Id == id);
            return View(menu);
        }
    }
}