using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Rol : IdentityRole
    {
        public Rol() : base() { }

        public Rol(string rolnaam) : base(rolnaam)
        {

        }
        public Rol(string rolnaam, string beschrijving, DateTime aanmaakdatum) : base(rolnaam)
        {
            this.Beschrijving = beschrijving;
            this.Aanmaakdatum = aanmaakdatum;
        }
        public string Beschrijving { get; set; }
        public DateTime Aanmaakdatum { get; set; }
    }
}
