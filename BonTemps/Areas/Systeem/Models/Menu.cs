﻿using System;
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
        public string Menu_naam { get; set; }
        public string Beschrijving { get; set; }

        [ForeignKey("Consumptie")]
        public virtual ICollection<Consumptie> Consumpties { get; set; }
    }
}
