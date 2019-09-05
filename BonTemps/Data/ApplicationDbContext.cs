using System;
using System.Collections.Generic;
using System.Text;
using BonTemps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.ReserveerSysteem.Models;

namespace BonTemps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }       
        
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Klantgegevens> Klantgegevens { get; set; }
        public DbSet<BonTemps.Areas.ReserveerSysteem.Models.Reservering> Reservering { get; set; }
    }
}
