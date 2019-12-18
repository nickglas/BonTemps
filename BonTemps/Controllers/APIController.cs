using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BonTemps.Controllers.API
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class APIController : ControllerBase
    {
        private ApplicationDbContext _context;
        public APIController(ApplicationDbContext context)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            _context = context;
        }


    [HttpGet]
        public async Task<JsonResult> GetConsumptie(int? id)
        {
            if (id == null)
            {
                var cons = await _context.Consumpties.Select(x => new Consumptie
                {
                    Id = x.Id,
                    Naam = x.Naam,
                    Beschrijving = x.Beschrijving,
                    Prijs = x.Prijs,
                    CategoryId = x.CategoryId,
                    ConsumptieMenu = x.ConsumptieMenu,
                    ConsumptieAllergenen = x.ConsumptieAllergenen
                }).ToListAsync();

                return new JsonResult(cons);
            }
            else
            {
                var cons = await _context.Consumpties.Where(x=>x.Id == id).Select(x => new Consumptie
                {
                    Id = x.Id,
                    Naam = x.Naam,
                    Beschrijving = x.Beschrijving,
                    Prijs = x.Prijs,
                    CategoryId = x.CategoryId,
                    ConsumptieMenu = x.ConsumptieMenu,
                    ConsumptieAllergenen = x.ConsumptieAllergenen
                }).FirstAsync();
                return new JsonResult(cons);
            }
        }


        public IActionResult Getresinfo()
        {
            return new JsonResult(_context.ContactInfo);
        }

        [HttpGet]
        public async Task<JsonResult> GetMenu(int? id)
        {
            if (id == null)
            {
                var menu = await _context.Menus.Select(x => new Menu
                {
                    Id = x.Id,
                    Menu_naam = x.Menu_naam,
                    Beschrijving = x.Beschrijving,
                    ConsumptieMenu = x.ConsumptieMenu,
                    ReserveringenMenus = x.ReserveringenMenus,
                    Consumpties = x.Consumpties
                }).ToListAsync();

                return new JsonResult(menu);
            }
            else
            {
                var menu = await _context.Menus.Where(x => x.Id == id).Select(x => new Menu
                {
                    Id = x.Id,
                    Menu_naam = x.Menu_naam,
                    Beschrijving = x.Beschrijving,
                    ConsumptieMenu = x.ConsumptieMenu,
                    ReserveringenMenus = x.ReserveringenMenus,
                    Consumpties = x.Consumpties
                }).FirstAsync();
                return new JsonResult(menu);
            }
        }

        public async Task<IActionResult> MakeReservervation()
        {
            Reservering res = new Reservering()
            {
                NaamReserveerder = "test",
                Email = "Test",
                HuisTelefoonNummer = "123",
                MobielTelefoonNummer = "123",
                AantalPersonen = 1,
                ReserveringAangemaakt = DateTime.Now,
                ReserveringsDatum = DateTime.Now,
                Goedkeuring = false,
                tafelsId = _context.Tafels.Where(x => x.Bezet == false).FirstOrDefault().Id
            };
            await _context.Reserveringen.AddAsync(res);
            await _context.SaveChangesAsync();
            return Ok();
        }
        

        [HttpPost]
        public JsonResult PassIntFromView(string Content)
        {
            Console.WriteLine("\n\nOBJECT ID : " + Content+"\n\n");
            return new JsonResult(Content);
        }
    }
        
}
