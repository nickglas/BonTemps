using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Consumptie
    {
        string Category_eten = "Eten";
        string Category_Drinken = "Drinken";
        string Category_Deserts = "Deserts";



        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Prijs { get; set; }
        public Category Category { get; set; }
    }
}
