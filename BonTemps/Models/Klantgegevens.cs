using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Klantgegevens
    {
        [Key]
        public int KlantGegevensId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Geslacht { get; set; }
        public string TelefoonNummer { get; set; }
    }
}
