using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using BonTemps.Models;
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
        public JsonResult GetConsumptie()
        {
            List<Consumptie> Cons = _context.Consumpties.ToList();
            var Content = JsonConvert.SerializeObject(Cons);
            return new JsonResult(new { TestObject = Cons });
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
