using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BonTemps.Areas.Chef.Controllers
{
    public class ChefBoardController : Controller
    {
        [Area("Chef")]
        public IActionResult Index()
        {
            return View();
        }
    }
}