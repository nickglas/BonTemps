using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Menu_naam { get; set; }
        public string Beschrijving { get; set; }
        public List<Consumptie> Items { get; set; }
        public int ConsumptieId { get; set; }
    }
}
