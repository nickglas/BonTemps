using BonTemps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class ReserveringenMenu
    {
        public Reservering Reservering { get; set; }
        public int ReserveringsId { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
