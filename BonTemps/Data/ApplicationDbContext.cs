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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Menu en consumptie koppel
            builder.Entity<ConsumptieMenu>()
                .HasKey(bc => new { bc.ConsumptieId, bc.MenuId });
            builder.Entity<ConsumptieMenu>()
                .HasOne(bc => bc.Consumptie)
                .WithMany(b => b.ConsumptieMenu)
                .HasForeignKey(bc => bc.ConsumptieId);
            builder.Entity<ConsumptieMenu>()
                .HasOne(bc => bc.Menu)
                .WithMany(c => c.ConsumptieMenu)
                .HasForeignKey(bc => bc.MenuId);

            //consumptie en allergenen koppel
            builder.Entity<ConsumptieAllergenen>()
                .HasKey(ca => new { ca.ConsumptieId, ca.AllergenenId });
            builder.Entity<ConsumptieAllergenen>()
                .HasOne(ca => ca.Consumptie)
                .WithMany(a => a.ConsumptieAllergenen)
                .HasForeignKey(ca => ca.ConsumptieId);
            builder.Entity<ConsumptieAllergenen>()
                .HasOne(ca => ca.Allergenen)
                .WithMany(c => c.ConsumptieAllergenen)
                .HasForeignKey(ca => ca.AllergenenId);

            //Reservering en Menu koppel
            builder.Entity<ReserveringenMenu>()
                .HasKey(ca => new { ca.MenuId, ca.ReserveringsId });
            builder.Entity<ReserveringenMenu>()
                .HasOne(ca => ca.Menu)
                .WithMany(ca => ca.ReserveringenMenus)
                .HasForeignKey(ca => ca.MenuId);
            builder.Entity<ReserveringenMenu>()
                .HasOne(ca => ca.Reservering)
                .WithMany(ca => ca.ReserveringenMenus)
                .HasForeignKey(ca => ca.ReserveringsId);

                



            base.OnModelCreating(builder);
        }

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
        public DbSet<BonTemps.Areas.Systeem.Models.Email> Email { get; set; }
        public DbSet<BonTemps.Areas.Systeem.Models.Allergenen> Allergenen { get; set; }
        public DbSet<BonTemps.Areas.Systeem.Models.ConsumptieAllergenen> ConsumptieAllergenen { get; set; }
        public DbSet<BonTemps.Areas.Systeem.Models.ConsumptieMenu> ConsumptieMenu { get; set; }
        public DbSet<BonTemps.Areas.Systeem.Models.ReserveringenMenu> ReserveringenMenu { get; set; }




    }
}   
