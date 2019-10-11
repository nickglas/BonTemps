using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Ontvanger { get; set; }
        public string Onderwerp { get; set; }
        public string  Text { get; set; }
        public DateTime VerzendDatum { get; set; }
    }
}
