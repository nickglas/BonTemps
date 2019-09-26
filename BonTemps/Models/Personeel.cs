using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Personeel : IdentityUser
    {
        public Personeel() : base()
        {

        }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }
        
        public DateTime Aanmaakdatum { get; set; }
    }
}
