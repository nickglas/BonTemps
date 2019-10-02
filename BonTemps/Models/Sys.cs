using BonTemps.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Sys
    {
        public static async Task CheckAccount(ApplicationDbContext _context, UserManager<Klant> _usermanager, SignInManager<Klant> signmanager, string username)
        {
            if (_context.Klanten.Where(x=>x.UserName == username).Count() == 0)
            {
                await signmanager.SignOutAsync();
            }
        }
    }
}
