using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Allergenen
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public string AllergenenIcoon { get; set; }
        public ICollection<ConsumptieAllergenen> ConsAller { get; set; }
    }
}
