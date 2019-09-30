using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class BestellingArchief
    {
        public int Id { get; set; }

        public string Consumptie { get; set; }

        public int TafelsId { get; set; }

        public DateTime Bestellingsdatum_Tijd { get; set; }
        public DateTime Bestellingsdatum_afgerond { get; set; }
        public DateTime Archiveerdatum { get; set; }
    }
}
