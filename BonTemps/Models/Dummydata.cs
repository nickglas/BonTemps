using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Dummydata
    {
        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<Klant> userManager,
                             RoleManager<Rol> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";
            String adminId3 = "";

            string role1 = "Admin";
            string desc1 = "Administrator rol die alles kan aanpassen in het systeem.";

            string role2 = "Manager";
            string desc2 = "Managers van het bedrijf.";

            string role3 = "Chef";
            string desc3 = "Koks van het bedrijf.";

            string role4 = "Bediening";
            string desc4 = "Bediening van het bedrijf.";

            string role5 = "Klant";
            string desc5 = "Klanten.";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new Rol(role1, desc1, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new Rol(role2, desc2, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new Rol(role3, desc3, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(role4) == null)
            {
                await roleManager.CreateAsync(new Rol(role4, desc4, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(role5) == null)
            {
                await roleManager.CreateAsync(new Rol(role5, desc5, DateTime.Today));
            }
            UpdateCategory(context);
            UpdateItems(context);

            if (await userManager.FindByNameAsync("nickglasss@hotmail.nl") == null)
            {

                var user = new Klant
                {
                    //KlantId = context.Klanten.Count() + 1,
                    UserName = "nickglass@hotmail.nl",
                    Email = "nickglass@hotmail.nl",
                    PhoneNumber = "6902341234",
                    Klantgegevens = new Klantgegevens
                    {
                        Voornaam = "Nick",
                        Achternaam = "Glass",
                        GeboorteDatum = DateTime.Now,
                        Geslacht = "Man",
                        TelefoonNummer = "0645473290",
                    },
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            await context.SaveChangesAsync();

        }

        public static void UpdateCategory(ApplicationDbContext _context)
        {
            Console.WriteLine("Updating category");
            List<Category> check = new List<Category>();
            Category eten = new Category
            {
                Naam = "Eten",
                Beschrijving = "Alles wat je kan eten"
            };
            check.Add(eten);
            Category drinken = new Category
            {
                Naam = "Drinken",
                Beschrijving = "Alles wat je kan drinken"
            };
            check.Add(drinken);
            Category deserts = new Category
            {
                Naam = "Deserts",
                Beschrijving = "Alle deserts"
            };
            check.Add(deserts);
            foreach (var item in check)
            {
                int i = _context.Categories.Where(x => x.Naam == item.Naam).Count();
                if (i == 0)
                {
                    _context.Add(item);
                }
            }
            _context.SaveChanges();
        }
        public static void UpdateItems(ApplicationDbContext _context)
        {

            Console.WriteLine("Updating Items");
            List<Consumptie> check = new List<Consumptie>();
            Consumptie eten = new Consumptie
            {
                Naam = "Spaghetti",
                Beschrijving = "Spaghetti Bolognesse",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Eten").First()
            };
            check.Add(eten);
            Consumptie drinken = new Consumptie
            {
                Naam = "Coca Cola",
                Beschrijving = "Cola",
                Prijs = 2.50,
                Category = _context.Categories.Where(x => x.Naam == "Drinken").First()
            };
            check.Add(drinken);
            Consumptie deserts = new Consumptie
            {
                Naam = "Dame blanche",
                Beschrijving = "ijs",
                Prijs = 3.25,
                Category = _context.Categories.Where(x => x.Naam == "Deserts").First()
            };
            check.Add(deserts);
            foreach (var item in check)
            {
                int i = _context.Consumpties.Where(x => x.Naam == item.Naam).Count();
                if (i == 0)
                {
                    _context.Consumpties.Add(item);
                }
            }
            _context.SaveChanges();
        }

    }
}

