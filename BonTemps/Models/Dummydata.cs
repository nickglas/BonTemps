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
            string desc1 = "This is the administrator role";

            string role2 = "Gebruiker";
            string desc2 = "This is the members role";

            string role3 = "Author";
            string desc3 = "This is the Author role";

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

    }
}

