using BonTemps.Areas.Systeem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Reservering
    {
        public int Id { get; set; }
        [Required]
        public string NaamReserveerder { get; set; }
        [Required]
        public string Email { get; set; }
        public string HuisTelefoonNummer { get; set; }
        [Required]
        [Display(Name = "Mobiel telefoonnummer")]
        public string MobielTelefoonNummer { get; set; }
        [Required]
        [Display(Name = "Aantal personen")]
        public int AantalPersonen { get; set; }
        [Required]
        public bool Goedkeuring { get; set; }
        public string Opmerking { get; set; }

        [Required]
        public DateTime ReserveringsDatum { get; set; }
        [Required]
        [Display(Name = "Selecteer reserverings datum")]
        public DateTime ReserveringAangemaakt { get; set; }

        [ForeignKey("Menu")]
        public virtual ICollection<Menu> Menu { get; set; }
        [ForeignKey("Bestelling")]
        public virtual ICollection<Bestelling> Bestellingen { get; set; }
        [ForeignKey("Gebruiker")]
        public virtual ICollection<Gebruiker> Gebruiker { get; set; }

        public ICollection<ReserveringenMenu> ReserveringenMenus { get; set; }


    }
}
