using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonTemps.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]

    public class ManagerBoardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IApplicationLifetime _lifetime;
        

        public ManagerBoardController(ApplicationDbContext context, IApplicationLifetime lifetime)
        {
            _lifetime = lifetime;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async void Shutdown()
        {
           await Sys.RestartSystem(_lifetime);
        }
    }
}