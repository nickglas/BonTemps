using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.ReserveerSysteem.Models
{
    public class Reservering
    {
        [Key]
        public int ReserveringId { get; set; }

        public string Voornaam { get; set; }
        public string Toevoeging { get; set; }
        public string Achternaam { get; set; }
        public int Telefoonnummer { get; set; }
        public int MobielNummer { get; set; }
        public int AantalPersonen { get; set; }
        public DateTime ReserveeringsDatum { get; set; }

    }
}
