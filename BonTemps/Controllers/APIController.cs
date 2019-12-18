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

        public IActionResult GetAllergenen()
        {
            return new JsonResult(_context.Allergenen);
        }

        public IActionResult Getresinfo()
        {
            return new JsonResult(_context.ContactInfo);
        }

        [HttpGet]
        public JsonResult GetMenu()
        {
            List<Menu> menu = _context.Menus.ToList();
            var Content = JsonConvert.SerializeObject(menu);
            return new JsonResult(new { TestObject = menu });
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
    }
        
}
