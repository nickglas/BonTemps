using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Display(Name = "Menu naam")]
        [Required(ErrorMessage = "U dient een menu naam in te vullen")]
        public string Menu_naam { get; set; }
        [Required(ErrorMessage = "U dient een beschrijving in te vullen")]
        public string Beschrijving { get; set; }

        public virtual ICollection<Consumptie> Consumpties { get; set; }
        public ICollection<ConsumptieMenu> ConsumptieMenu { get; set; }
        public ICollection<ReserveringenMenu> ReserveringenMenus { get; set; }

    }
}
