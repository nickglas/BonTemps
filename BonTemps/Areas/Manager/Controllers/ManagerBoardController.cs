using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonTemps.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerBoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerBoardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}