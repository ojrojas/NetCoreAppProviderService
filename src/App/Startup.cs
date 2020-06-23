using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cinte.Api.Services.Tokens;
using Cinte.Core.Infraestructure;
using Cinte.Infraestructure.Data;
using Cinte.Infraestructure.Identity;
using Cinte.Infraestructure.RequestProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddDbContext<CinteDbContext>(c =>
            c.UseSqlite("Data Source=/home/orojasg/Sources/Test/NetCore/NetCoreAppProviderService/src/Api/cintedb.db"));
         
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlite("Data Source=/home/orojasg/Sources/Test/NetCore/NetCoreAppProviderService/src/Api/indentitydb.db"));

            services.AddIdentity<Usuario, IdentityRole>()
          .AddEntityFrameworkStores<AppIdentityDbContext>()
          .AddDefaultTokenProviders();

          services.ConfigureApplicationCookie(options =>
    {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(120);

        options.LoginPath = "/Manage/Login";
        options.SlidingExpiration = true;
    });

            services.AddCors(options =>
             options.AddPolicy("CorsPolicy",
                 builder => builder
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials()
                 ));

            services.AddScoped<ICacheProvider, CacheProvider>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
