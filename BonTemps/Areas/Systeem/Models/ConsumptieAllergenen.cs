using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class ConsumptieAllergenen
    {
        public int Id { get; set; }
        public Consumptie Consumptie { get; set; }
        public int ConsumptieId { get; set; }
        public Allergenen Allergenen { get; set; }
        public int AllergenenId { get; set; }
    }

}