using BonTemps.Areas.Manager.Models;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

            //checktable();

            await UpdateMenu(context);
            await UpdateCategory(context);
            await UpdateItems(context);
            await UpdateSystemAccounts(context, userManager);
            await UpdateContactInfo(context);
            await UpdateAllergenen(context);
            await UpdateTafels(context);

            await KoppelAllergeen(context);

            await UpdateConsumptieMenu(context);


            await KoppelMenu(context);
            //await KoppelReserveringMenu(context);

            



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

        public static async Task KoppelReserveringMenu(ApplicationDbContext _context)
        {
            List<ReserveringenMenu> menus = new List<ReserveringenMenu>();
            ReserveringenMenu menu = new ReserveringenMenu();
            menu.MenuId = 1;
            menu.ReserveringsId = 1;
            menus.Add(menu);

            Reservering res = new Reservering();
            res.AantalPersonen = 1;
            res.Email = "Nickglas@hotmail.nl";
            res.Goedkeuring = true;
            res.HuisTelefoonNummer = "324234";
            res.MobielTelefoonNummer = "324234";
            res.ReserveringsDatum = DateTime.Now;
            res.Opmerking = "Opmerking";
            res.NaamReserveerder = "Marco";


            res.ReserveringenMenus = menus;

            _context.Reserveringen.Add(res);
            await _context.SaveChangesAsync();

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
                Beschrijving = "Het eerste gerecht dat je gereserveerd krijgt."
            };
            check.Add(voorgerecht);
            Category drinken = new Category
            {
                Naam = "Drinken",
                Beschrijving = "Alle drankjes."
            };
            check.Add(drinken);
            Category nagerecht = new Category
            {
                Naam = "Nagerecht",
                Beschrijving = "Alle deserts."
            };
            check.Add(nagerecht);
            Category hoofdgerecht = new Category
            {
                Naam = "Hoofdgerecht",
                Beschrijving = "Het hoofdgerecht."
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
            Consumptie voorgerecht = new Consumptie
            {
                Naam = "Tomaten soep",
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
                Naam = "Franse Uiensoep",
                Beschrijving = "Heerlijke soep gemaakt van franse uien",
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
                Beschrijving = "Heerlijke chocolade dessert",
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
            Consumptie flam = new Consumptie
            {
                Naam = "Elsässer Flammkuchen",
                Beschrijving = "Elsässer Flammkuchen",
                Prijs = 7.50,
                Category = _context.Categories.Where(x => x.Naam == "Hoofdgerecht").First(),
            };
            check.Add(flam);
            Consumptie boeuf = new Consumptie
            {
                Naam = "Boeuf Bourguignon",
                Beschrijving = "iets wat lijkt op champion soep met vlees erin",
                Prijs = 5.50,
                Category = _context.Categories.Where(x => x.Naam == "Voorgerecht").First(),
            };
            Consumptie madeleines = new Consumptie
            {
                Naam = "Madeleines",
                Beschrijving = "Franse koekies",
                Prijs = 4.50,
                Category = _context.Categories.Where(x => x.Naam == "Nagerecht").First(),
            };
            check.Add(madeleines);
            Consumptie chocolademelk = new Consumptie
            {
                Naam = "Chocolade Melk",
                Beschrijving = "Warme chocolade melk met slageroom",
                Prijs = 2.50,
                Category = _context.Categories.Where(x => x.Naam == "Drinken").First(),
            };
            check.Add(chocolademelk);
            check.Add(boeuf);
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
            g.ConsumptieId = 8;
            check.Add(g);

            ConsumptieMenu h = new ConsumptieMenu();
            h.MenuId = 3;
            h.ConsumptieId = 9;
            check.Add(h);

            ConsumptieMenu i = new ConsumptieMenu();
            i.MenuId = 3;
            i.ConsumptieId = 10;
            check.Add(i);

            ConsumptieMenu j = new ConsumptieMenu();
            j.MenuId = 3;
            j.ConsumptieId = 11;
            check.Add(j);

            ConsumptieMenu k = new ConsumptieMenu();
            k.MenuId = 3;
            k.ConsumptieId = 11;
            check.Add(k);
            foreach (var item in check)
            {
                int q = _context.ConsumptieMenu.Where(x => x.ConsumptieId == item.ConsumptieId).Count();
                if (q == 0)
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
                AllergenenIcoon = "pinda.png",
                Beschrijving = "Bevat sporen van pinda's."
            };
            check.Add(allergeen1);
            Allergenen allergeen2 = new Allergenen
            {
                AllergenenIcoon = "lactose.png",
                Beschrijving = "Bevat sporen van lactose."
            };
            check.Add(allergeen2);
            Allergenen allergeen3 = new Allergenen
            {
                AllergenenIcoon = "vis.png",
                Beschrijving = "Bevat sporen van vis, schaal en schelpdieren."
            };
            check.Add(allergeen3);
            Allergenen allergeen4 = new Allergenen
            {
                AllergenenIcoon = "gluten.png",
                Beschrijving = "Bevat sporen van gluten."
            };
            check.Add(allergeen4);
            Allergenen allergeen5 = new Allergenen
            {
                AllergenenIcoon = "soja.png",
                Beschrijving = "Bevat sporen van sojabonen."
            };
            check.Add(allergeen5);


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
            Consaller.AllergenenId = 4;
            Consaller.ConsumptieId = 1;
            //aller.Allergenen = _context.Allergenen.FirstOrDefault();
            //aller.Consumptie = _context.Consumpties.FirstOrDefault();
            lijst.Add(Consaller);

            Consumptie cons = new Consumptie();
            cons.Naam = "Spaghetti";
            cons.ConsumptieAllergenen = lijst;
            cons.Beschrijving = "Spaghetti Bolgnese";
            cons.Prijs = 6.50;
            cons.CategoryId = 4;
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
        public static async Task UpdateTafels(ApplicationDbContext _context)
        {
            Console.WriteLine("Updating tafels");
            List<Tafels> check = new List<Tafels>();

            Tafels tafel1 = new Tafels
            {
                TafelNaam = "Tafel 1",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel1);

            Tafels tafel2 = new Tafels
            {
                TafelNaam = "Tafel 2",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel2);

            Tafels tafel3 = new Tafels
            {
                TafelNaam = "Tafel 3",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel3);

            Tafels tafel4 = new Tafels
            {
                TafelNaam = "Tafel 4",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel4);

            Tafels tafel5 = new Tafels
            {
                TafelNaam = "Tafel 5",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel5);

            Tafels tafel6 = new Tafels
            {
                TafelNaam = "Tafel 6",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel6);

            Tafels tafel7 = new Tafels
            {
                TafelNaam = "Tafel 7",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel7);


            Tafels tafel8 = new Tafels
            {
                TafelNaam = "Tafel 8",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel8);

            Tafels tafel9 = new Tafels
            {
                TafelNaam = "Tafel 9",

                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel9);

            Tafels tafel10 = new Tafels
            {
                TafelNaam = "Tafel 10",
                Zitplaatsen = 6,
                Bezet = false
            };
            check.Add(tafel10);

            foreach (var item in check)
            {
                int i = _context.Tafels.Where(x => x.TafelNaam == item.TafelNaam).Count();
                if (i == 0)
                {
                    _context.Tafels.Add(item);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}

