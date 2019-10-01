using System;
using System.Collections.Generic;
using System.Text;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Manager.Models;

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
        public DbSet<Tafels> Tafels { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }

        //Andere area
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Consumptie> Consumpties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personeel> Personeel { get; set; }
        public DbSet<BonTemps.Areas.Manager.Models.ContactInfo> ContactInfo { get; set; }
        public DbSet<BestellingArchief> BestellingArchief { get; set; }
    }
}
