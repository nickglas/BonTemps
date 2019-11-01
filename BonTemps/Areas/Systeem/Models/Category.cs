using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "U dient een naam in te vullen")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "U dient een beschrijving in te vullen")]
        public string Beschrijving { get; set; }
    }
}
