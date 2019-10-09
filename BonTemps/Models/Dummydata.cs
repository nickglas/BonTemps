using BonTemps.Areas.Manager.Models;
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
        private static string password = "P@$$w0rd";

        public static string ManagerRol = "Manager";
        public static string ManagerRolBeschrijving = "Managers/Admins van het bedrijf.";

        public static string ChefRol = "Chef";
        public static string ChefRolBeschrijving = "Koks van het bedrijf.";

        public static string BedieningRol = "Bediening";
        public static string BedieningRolBeschrijving = "Bediening van het bedrijf.";

        public static string KlantRol = "Klant";
        public static string KlantRolBeschrijving = "Klanten.";

        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<Klant> userManager,
                             RoleManager<Rol> roleManager)
        {
            await UpdateMenu(context);
            context.Database.EnsureCreated();
            if (await roleManager.FindByNameAsync(ManagerRol) == null)
            {
                await roleManager.CreateAsync(new Rol(ManagerRol, ManagerRolBeschrijving, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(ChefRol) == null)
            {
                await roleManager.CreateAsync(new Rol(ChefRol, ChefRolBeschrijving, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(BedieningRol) == null)
            {
                await roleManager.CreateAsync(new Rol(BedieningRol, BedieningRolBeschrijving, DateTime.Today));
            }
            if (await roleManager.FindByNameAsync(KlantRol) == null)
            {
                await roleManager.CreateAsync(new Rol(KlantRol, KlantRolBeschrijving, DateTime.Today));
            }

            await UpdateMenu(context);
            await UpdateCategory(context);
            await UpdateItems(context);
            await UpdateSystemAccounts(context, userManager);
            await UpdateContactInfo(context);

            
            
        }

        public static async Task UpdateContactInfo(ApplicationDbContext _context) 
        {
            if (_context.ContactInfo.Count() == 0)
            {
                ContactInfo info = new ContactInfo
                {
                    Adres = "Hoofdstraat 82",
                    Postcode = "1931GL",
                    Telefoonnummer = "5063209",
                    Email = "Bontemps@gmail.com",

                    //Datums en tijden
                    MaandagOpen = "16:00",
                    MaandagSluit = "23:00",
                    DinsdagOpen = "16:00",
                    DinsdagSluit = "23:00",
                    WoensdagOpen = "16:00",
                    WoensdagSluit = "23:00",
                    DonderdagOpen = "16:00",
                    DonderdagSluit = "23:00",
                    VrijdagOpen = "16:00",
                    VrijdagSluit = "23:00",
                    ZaterdagOpen = "16:00",
                    ZaterdagSluit = "23:00",
                    ZondagOpen = "16:00",
                    ZondagSluit = "23:00"
                };
                await _context.ContactInfo.AddAsync(info);
                await _context.SaveChangesAsync();
            }
        }
        
        public static async Task UpdateSystemAccounts(ApplicationDbContext _context, UserManager<Klant> userManager)
        {
            if (await userManager.FindByNameAsync("manager@bontemps.nl") == null)
            {
                var user = new Klant
                {
                    UserName = "manager@bontemps.nl",
                    Email = "manager@bontemps.nl",
                    PhoneNumber = "0645473290",
                    Rolnaam = ManagerRol,
                    Klantgegevens = new Klantgegevens
                    {
                        Voornaam = "Nick",
                        Achternaam = "Glas",
                        GeboorteDatum = DateTime.Now,
                        Geslacht = "Man",
                        TelefoonNummer = "0645473290",

                    },
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, ManagerRol);
                }
                await _context.SaveChangesAsync();
            }

            if (await userManager.FindByNameAsync("nickglas@hotmail.nl") == null)
            {
                var user = new Klant
                {
                    UserName = "nickglas@hotmail.nl",
                    Email = "nickglas@hotmail.nl",
                    PhoneNumber = "0645473290",
                    Rolnaam = ManagerRol,
                    Klantgegevens = new Klantgegevens
                    {
                        Voornaam = "Nick",
                        Achternaam = "Glas",
                        GeboorteDatum = DateTime.Now,
                        Geslacht = "Man",
                        TelefoonNummer = "0645473290",

                    },
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, ManagerRol);
                }
                await _context.SaveChangesAsync();
            }

            if (await userManager.FindByNameAsync("chef@bontemps.nl") == null)
            {
                var personeel = new Klant
                {
                    Email = "chef@bontemps.nl",
                    UserName = "chef@bontemps.nl",
                    Rolnaam = ChefRol
                };
                var result = await userManager.CreateAsync(personeel);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(personeel, password);
                    await userManager.AddToRoleAsync(personeel, ChefRol);
                }
                await _context.SaveChangesAsync();
            }

            if (await userManager.FindByNameAsync("bediening@bontemps.nl") == null)
            {
                var personeel = new Klant
                {
                    Email = "bediening@bontemps.nl",
                    UserName = "bediening@bontemps.nl",
                    Rolnaam = BedieningRol
                };
                var result = await userManager.CreateAsync(personeel);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(personeel, password);
                    await userManager.AddToRoleAsync(personeel, ChefRol);
                }
                await _context.SaveChangesAsync();
            }
            if (await userManager.FindByNameAsync("klant@bontemps.nl") == null)
            {
                var personeel = new Klant
                {
                    Email = "klant@bontemps.nl",
                    UserName = "klant@bontemps.nl",
                    Rolnaam = KlantRol
                };
                var result = await userManager.CreateAsync(personeel);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(personeel, password);
                    await userManager.AddToRoleAsync(personeel, ChefRol);
                }
                await _context.SaveChangesAsync();
            }
        }



        public static async Task UpdateMenu(ApplicationDbContext _context)
        {
            List<Menu> check = new List<Menu>();

            Menu Spaget = new Menu
            {
                Menu_naam = "Spaget",
                Beschrijving = "Menu met Spaget",
            };
            check.Add(Spaget);

            foreach (var item in check)
            {
                int i = _context.Menus.Where(x => x.Menu_naam == item.Menu_naam).Count();
                if (i == 0)
                {
                    await _context.AddAsync(item);
                }
            }
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
        }

        public static async Task UpdateCategory(ApplicationDbContext _context)
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
                   await _context.AddAsync(item);
                }
            }
           await _context.SaveChangesAsync();
        }
        public static async Task UpdateItems(ApplicationDbContext _context)
        {

            Console.WriteLine("Updating Items");
            List<Consumptie> check = new List<Consumptie>();
            Consumptie eten = new Consumptie
            {
                Naam = "Spaghetti",
                Beschrijving = "Spaghetti Bolognesse",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Eten").First(),
                Menu = _context.Menus.Where(x => x.Menu_naam == "Spaget").First()
            };
            check.Add(eten);
            Consumptie drinken = new Consumptie
            {
                Naam = "Coca Cola",
                Beschrijving = "Cola",
                Prijs = 2.50,
                Category = _context.Categories.Where(x => x.Naam == "Drinken").First(),
                Menu = _context.Menus.Where(x => x.Menu_naam == "Spaget").First()
            };
            check.Add(drinken);
            Consumptie deserts = new Consumptie
            {
                Naam = "Dame blanche",
                Beschrijving = "ijs",
                Prijs = 3.25,
                Category = _context.Categories.Where(x => x.Naam == "Deserts").First(),
                Menu = _context.Menus.Where(x => x.Menu_naam == "Spaget").First()
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
            await _context.SaveChangesAsync();
        }


    }
}

