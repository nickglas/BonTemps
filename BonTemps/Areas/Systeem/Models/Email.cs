using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Email
    {
        public int Id { get; set; }
        [Required(ErrorMessage="U heeft geen ontvanger ingevoerd")]
        public string Ontvanger { get; set; }
        [Required(ErrorMessage = "U heeft geen onderwerp ingevuld")]
        public string Onderwerp { get; set; }
        public string  Text { get; set; }
        public DateTime VerzendDatum { get; set; }
    }
}
