using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BonTemps.Models;
using System.IO;
using Rotativa.AspNetCore;
using System.Threading;
using BonTemps.Areas.Systeem.Models;

namespace BonTemps
{
    public class Startup
    {
        
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            
            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
                services.AddIdentity<Klant,Rol>(
                    options => options.Stores.MaxLengthForKeys = 128
                    )
                    .AddDefaultUI(UIFramework.Bootstrap4)
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                // sessions 
                services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromDays(1);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });



            }

           

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context, RoleManager<Rol> rolemanager, UserManager<Klant>usermanager, IApplicationLifetime applicationLifetime)
            {
                app.UseSession();
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseAuthentication();

                app.UseStaticFiles();

                    

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Reserveringen}/{action=Index}/{id?}"
                    );
                });
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=ChefBoard}/{action=Index}/{id?}"
                    );
                });
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=ManagerBoard}/{action=Index}/{id?}"
                    );
                });

            RotativaConfiguration.Setup(env);    

              //  Dummydata.Initialize(context, usermanager, rolemanager).Wait();

            //DummyData.UserTest(context, usermanager, rolemanager).Wait();
            //DummyData.AddLevels(context, usermanager, rolemanager).Wait();
            //DummyData.LoadCategory(context, env).Wait();

            //Thread thread = new Thread(SomeMethod);
            //thread.Start();

            //void SomeMethod()
            //{
            //    List<Reservering> res = context.Reserveringen.ToList();
            //    foreach (var item in res)
            //    {
                    
            //        DateTime date = item.ReserveringsDatum;
            //        if (item.ReserveringsDatum == date.AddHours(2))
            //        {

            //        }
            //    }
            //}

        }

      
        
    }
}
