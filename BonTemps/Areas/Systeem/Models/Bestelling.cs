using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, 15, ErrorMessage = "Het aantal moet minimaal 1 zijn, en mag maximaal 15 zijn")]
        [Required]
        public int Aantal { get; set; }


        //Tafel
        public Tafels Tafels { get; set; }
        public int TafelsId { get; set; }

        public DateTime Bestellingsdatum_Tijd { get; set; }
        public DateTime Bestellingsdatum_afgerond { get; set; }
        public bool Afgerond { get; set; }


    }
}
