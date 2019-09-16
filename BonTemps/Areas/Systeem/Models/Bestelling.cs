using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Bestelling
    {
        public int Id { get; set; }

        //Consumptie FK
        public Consumptie Consumptie  { get; set; }
        public int ConsumptieId { get; set; }

        //Tafel
        public Tafels Tafels { get; set; }
        public int TafelsId { get; set; }

        public DateTime Bestellingsdatum_Tijd { get; set; }
        public bool Afgerond { get; set; }


    }
}
