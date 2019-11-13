using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonTemps.Controllers.API
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class APIController : ControllerBase
    {
        private ApplicationDbContext _context;
        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public JsonResult Get()
        {
            Console.WriteLine("\n\n IETS !! \n\n");
            List<Consumptie> Cons = _context.Consumpties.ToList();

            var Content = JsonConvert.SerializeObject(Cons);
            return new JsonResult(new { TestObject = Cons });
        }

    }
}