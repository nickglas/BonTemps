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
            await UpdateAllergenen(context);


            await KoppelAllergeen(context);

            await UpdateConsumptieMenu(context);


            await KoppelMenu(context);



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
                    await userManager.AddToRoleAsync(personeel, KlantRol);
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
            Menu Ratatouille = new Menu
            {
                Menu_naam = "Ratatouille",
                Beschrijving = "Menu met Ratatouille",
            };
            check.Add(Ratatouille);
            Menu flamkuchen = new Menu
            {
                Menu_naam = "Elsässer Flammkuchen",
                Beschrijving = "Menu met Elsässer Flammkuchen",
            };
            check.Add(flamkuchen);
            foreach (var item in check)
            {
                int i = _context.Menus.Where(x => x.Menu_naam == item.Menu_naam).Count();
                if (i == 0)
                {
                    await _context.AddAsync(item);
                }
            }
            await _context.SaveChangesAsync();
        }

        public static async Task UpdateCategory(ApplicationDbContext _context)
        {
            Console.WriteLine("Updating category");

            List<Category> check = new List<Category>();
            Category voorgerecht = new Category
            {
                Naam = "Voorgerecht",
                Beschrijving = "Alles wat je kan eten"
            };
            check.Add(voorgerecht);
            Category drinken = new Category
            {
                Naam = "Drinken",
                Beschrijving = "Alles wat je kan drinken"
            };
            check.Add(drinken);
            Category nagerecht = new Category
            {
                Naam = "Nagerecht",
                Beschrijving = "Alle deserts"
            };
            check.Add(nagerecht);
            Category hoofdgerecht = new Category
            {
                Naam = "Hoofdgerecht",
                Beschrijving = "Alle deserts"
            };
            check.Add(hoofdgerecht);
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
            Consumptie hoofdgerecht = new Consumptie
            {
                Naam = "Spaghetti",
                Beschrijving = "Spaghetti Bolognesse",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Hoofdgerecht").First(),
            };
            check.Add(hoofdgerecht);
            Consumptie voorgerecht = new Consumptie
            {
                Naam = "Tomatten soep",
                Beschrijving = "soep gemaakt van tomatten",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Voorgerecht").First(),
            };
            Consumptie drinken = new Consumptie
            {
                Naam = "Coca Cola",
                Beschrijving = "Cola",
                Prijs = 2.50,
                Category = _context.Categories.Where(x => x.Naam == "Drinken").First(),
            };
            check.Add(drinken);
            Consumptie nagerecht = new Consumptie
            {
                Naam = "Dame blanche",
                Beschrijving = "ijs",
                Prijs = 3.25,
                Category = _context.Categories.Where(x => x.Naam == "Nagerecht").First(),
            };
            check.Add(nagerecht);
            Consumptie franseuiensoep = new Consumptie
            {
                Naam = "franse uiensoep",
                Beschrijving = "soep gemaakt van franse uien",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Voorgerecht").First(),
            };
            check.Add(franseuiensoep);
            Consumptie ratatouille = new Consumptie
            {
                Naam = "Ratatouille",
                Beschrijving = "Menu met Ratatouille",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Hoofdgerecht").First(),
            };
            check.Add(ratatouille);
            Consumptie moelleux = new Consumptie
            {
                Naam = "Moelleux au chocolat",
                Beschrijving = "soort van chocoladen taart brownie ding",
                Prijs = 6.50,
                Category = _context.Categories.Where(x => x.Naam == "Nagerecht").First(),
            };
            check.Add(moelleux);
            Consumptie icetea = new Consumptie
            {
                Naam = "Ice Tea",
                Beschrijving = "Ice Tea",
                Prijs = 3.50,
                Category = _context.Categories.Where(x => x.Naam == "Drinken").First(),
            };
            check.Add(icetea);
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
        
        public static async Task UpdateConsumptieMenu(ApplicationDbContext _context)
        {
            Console.WriteLine("Updating ConsumptieMenu");
            List<ConsumptieMenu> consumptiemenu = _context.ConsumptieMenu.ToList();
            List<ConsumptieMenu> check = new List<ConsumptieMenu>();

            ConsumptieMenu consumptiemenu1 = new ConsumptieMenu
            {
                MenuId = 1,
                ConsumptieId = 1
            };
            check.Add(consumptiemenu1);

            //ConsumptieMenu consumptiemenu2 = new ConsumptieMenu
            //{
            //    MenuId = 1,
            //    ConsumptieId = 2
            //};
            //check.Add(consumptiemenu2);

            ConsumptieMenu a = new ConsumptieMenu();
            a.MenuId = 1;
            a.ConsumptieId = 2;
            check.Add(a);

            //ConsumptieMenu consumptiemenu3 = new ConsumptieMenu
            //{
            //    MenuId = 1,
            //    ConsumptieId = 3
            //};
            //check.Add(consumptiemenu3);

            ConsumptieMenu b = new ConsumptieMenu();
            b.MenuId = 1;
            b.ConsumptieId = 3;
            check.Add(b);

            //ConsumptieMenu consumptiemenu4 = new ConsumptieMenu
            //{
            //    MenuId = 1,
            //    ConsumptieId = 4
            //};
            //check.Add(consumptiemenu4);

            ConsumptieMenu c = new ConsumptieMenu();
            c.MenuId = 1;
            c.ConsumptieId = 4;
            check.Add(c);


            //ConsumptieMenu consumptiemenu5 = new ConsumptieMenu
            //{
            //    MenuId = 2,
            //    ConsumptieId = 5
            //};
            //check.Add(consumptiemenu5);

            ConsumptieMenu d = new ConsumptieMenu();
            d.MenuId = 2;
            d.ConsumptieId = 5;
            check.Add(d);

            //ConsumptieMenu consumptiemenu6 = new ConsumptieMenu
            //{
            //    MenuId = 2,
            //    ConsumptieId = 6
            //};
            //check.Add(consumptiemenu6);

            ConsumptieMenu e = new ConsumptieMenu();
            e.MenuId = 2;
            e.ConsumptieId = 6;
            check.Add(e);

            //ConsumptieMenu consumptiemenu7 = new ConsumptieMenu
            //{
            //    MenuId = 2,
            //    ConsumptieId = 7
            //};
            //check.Add(consumptiemenu7);

            ConsumptieMenu f = new ConsumptieMenu();
            f.MenuId = 2;
            f.ConsumptieId = 7;
            check.Add(f);

            ////ConsumptieMenu consumptiemenu8 = new ConsumptieMenu
            ////{
            ////    MenuId = 2,
            ////    ConsumptieId = 8
            ////};
            ////check.Add(consumptiemenu8);

            ConsumptieMenu g = new ConsumptieMenu();
            g.MenuId = 2;
            g.ConsumptieId = 7;
            check.Add(g);

            foreach (var item in check)
            {
                int i = _context.ConsumptieMenu.Where(x => x.ConsumptieId == item.ConsumptieId).Count();
                if (i == 0)
                {
                    _context.ConsumptieMenu.Add(item);
                    await _context.SaveChangesAsync();
                }
            }
        }
        
        public static async Task UpdateAllergenen(ApplicationDbContext _context)
        {
            Console.WriteLine("Updating Allergenen");
            List<Allergenen> allergenen = _context.Allergenen.ToList();
            List<Allergenen> check = new List<Allergenen>();

            Allergenen allergeen1 = new Allergenen
            {
                AllergenenIcoon = "",
                Beschrijving = "Bevat sporen van pinda's"
            };
            check.Add(allergeen1);
            Allergenen allergeen2 = new Allergenen
            {
                AllergenenIcoon = "",
                Beschrijving = "Bevat sporen van lactose"
            };
            check.Add(allergeen2);
            Allergenen allergeen3 = new Allergenen
            {
                AllergenenIcoon = "",
                Beschrijving = "Bevat sporen van vis schaal en schelpdieren"
            };
            check.Add(allergeen3);


            foreach (var item in check)
            {
                int i = _context.Allergenen.Where(x => x.Beschrijving == item.Beschrijving).Count();
                if (i == 0)
                {
                    _context.Allergenen.Add(item);
                }
            }
            await _context.SaveChangesAsync();


        }
        public static async Task KoppelAllergeen(ApplicationDbContext _context)
        {
            List<ConsumptieAllergenen> lijst = new List<ConsumptieAllergenen>();
            ConsumptieAllergenen Consaller = new ConsumptieAllergenen();
            Consaller.AllergenenId = 1;
            Consaller.ConsumptieId = 1;
            //aller.Allergenen = _context.Allergenen.FirstOrDefault();
            //aller.Consumptie = _context.Consumpties.FirstOrDefault();
            lijst.Add(Consaller);

            Consumptie cons = new Consumptie();
            cons.Naam = "tes";
            cons.ConsumptieAllergenen = lijst;
            cons.Beschrijving = "tes";
            cons.Prijs = 1.1;
            cons.CategoryId = 1;

            _context.AddRange(cons);
            _context.SaveChanges();
        }

        public static async Task KoppelMenu(ApplicationDbContext _context)
        {
            List<ConsumptieMenu> test = new List<ConsumptieMenu>();
            ConsumptieMenu menu = new ConsumptieMenu();
            menu.ConsumptieId = 2;
            menu.MenuId = 2;
            //aller.Allergenen = _context.Allergenen.FirstOrDefault();
            //aller.Consumptie = _context.Consumpties.FirstOrDefault();
            test.Add(menu);

            Consumptie consumptie = new Consumptie();
            consumptie.ConsumptieMenu = test;
            consumptie.CategoryId = 1;
            consumptie.Beschrijving = "tset";
            consumptie.Naam = "test";
            consumptie.Prijs = 1.5;
            

            _context.Consumpties.Add(consumptie);
            await _context.SaveChangesAsync();
        }

    }
}

