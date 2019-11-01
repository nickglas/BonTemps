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
        [Required(ErrorMessage = "U dient een naam in te vullen")]
        public string NaamReserveerder { get; set; }
        [Required(ErrorMessage = "U dient een E-Mail adres in te vullen")]
        [EmailAddress(ErrorMessage = "Dit is een ongeldig E-Mail adres")]
        public string Email { get; set; }
        public string HuisTelefoonNummer { get; set; }
        [Required(ErrorMessage = "U dient een telefoonnummer in te vullen")]
        [Display(Name = "Mobiel telefoonnummer")]
        public string MobielTelefoonNummer { get; set; }
        [Required(ErrorMessage = "U dient een aantal in te vullen")]
        [Range(1, 60, ErrorMessage = "Een reservering moet minimaal uit 1 persoon bestaan, en maximaal uit 60 personen")]
        [Display(Name = "Aantal personen")]
        public int AantalPersonen { get; set; }
        [Required]
        public bool Goedkeuring { get; set; }
        public string Opmerking { get; set; }

        public Tafels tafels { get; set; }
        public int tafelsId { get; set; }

        [Required]
        public DateTime ReserveringsDatum { get; set; }
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
