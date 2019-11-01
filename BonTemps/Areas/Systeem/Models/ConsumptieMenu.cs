using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BonTemps.Areas.Systeem.Models
{
    public class ConsumptieMenu
    {
        public int Id { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        public Consumptie Consumptie { get; set; }
        public int ConsumptieId { get; set; }
    }
}
