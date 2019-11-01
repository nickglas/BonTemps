using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Tafels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "U dient het aantal zitplaatsen in te vullen")]
        [Range(2, 30, ErrorMessage = "Een tafel moet minimaal 2 zitplaatsen hebben, en mag maximaal 30 zitplaatsen hebben")]
        public int Zitplaatsen { get; set; }
        public bool Bezet { get; set; }
    }
}
