using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "U dient een naam in te vullen")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "U dient een beschrijving in te vullen")]
        public string Beschrijving { get; set; }
        [Required(ErrorMessage = "U dient een prijs in te vullen")]
        [Range(0.50, 999.99, ErrorMessage = "De prijs moet minimaal €0.50 zijn, en mag maximaal €999.99 zijn")]
        public double Prijs { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<ConsumptieAllergenen> ConsumptieAllergenen { get; set; }

        public ICollection<ConsumptieMenu> ConsumptieMenu { get; set; }
    }
}
