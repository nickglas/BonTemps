using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Reservering
    {
        public int Id { get; set; }
        public string NaamReserveerder { get; set; }
        public string Email { get; set; }
        public string HuisTelefoonNummer { get; set; }
        public string MobielTelefoonNummer { get; set; }
        public int AantalPersonen { get; set; }
        public DateTime ReserveringAangemaakt { get; set; }

       [Required]
       [Display(Name = "Selecteer reserverings datum")]
        public DateTime ReserveringsDatum { get; set; }
    }
}
