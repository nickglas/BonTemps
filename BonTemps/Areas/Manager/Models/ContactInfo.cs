using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Manager.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Telefoonnummer { get; set; }
        public string Email { get; set; }

        public string MaandagOpen { get; set; }
        public string MaandagSluit { get; set; }

        public string DinsdagOpen { get; set; }
        public string DinsdagSluit { get; set; }

        public string WoensdagOpen { get; set; }
        public string WoensdagSluit { get; set; }

        public string DonderdagOpen { get; set; }
        public string DonderdagSluit { get; set; }

        public string VrijdagOpen { get; set; }
        public string VrijdagSluit { get; set; }

        public string ZaterdagOpen { get; set; }
        public string ZaterdagSluit { get; set; }

        public string ZondagOpen { get; set; }
        public string ZondagSluit { get; set; }


    }
}
