using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BonTemps.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BonTemps
{
    public class Program
    {
        ApplicationDbContext _context;
        
        public static void Main(string[] args)
        { 
            try
            {
                FileStream fileStream = new FileStream("file.txt", FileMode.Open);
                string line = "";
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    line = reader.ReadLine();
                }
                if (line != "asdasd213eAAASFFIJ(JU@$!342dDA")
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
