using BonTemps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Areas.Systeem.Models
{
    public class Dashboard
    {
        public List<Klant> users;
        public List<Reservering> Reserveringen;
        public List<Tafels> Tafels;
        public double Omzet { get; set; }
    }
}
