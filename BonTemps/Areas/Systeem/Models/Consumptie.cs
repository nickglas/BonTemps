using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Consumptie
    {
        public static int Category_eten = 1;
        public static int Category_Drinken = 2;
        public static int Category_Deserts = 3;
               
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Prijs { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }


        public ICollection<ConsumptieAllergenen> ConsAller { get; set; }
    }
}
