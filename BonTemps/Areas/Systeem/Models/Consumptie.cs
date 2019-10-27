using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Consumptie
    {
        public static int Category_Voorgerecht = 1;
        public static int Category_Hoofdgerecht = 2;
        public static int Category_Nagerecht = 3;
        public static int Category_Drinken = 4;

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Prijs { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<ConsumptieAllergenen> ConsumptieAllergenen { get; set; }

        public ICollection<ConsumptieMenu> ConsumptieMenu { get; set; }
    }
}
