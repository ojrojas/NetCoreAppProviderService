using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orojas.Api.Services.Tokens;
using Orojas.Infraestructure.Data;
using Orojas.Infraestructure.Identity;
using Orojas.Infraestructure.RequestProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Api
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
            services.AddControllers();
            services.AddDbContext<OrojasDbContext>(c =>
               c.UseSqlite("Data Source=Orojasdb.db"));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite("Data Source=indentitydb.db"));

              services.AddIdentity<Usuario, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddCors(options =>
             options.AddPolicy("CorsPolicy",
                 builder => builder
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials()
                 ));

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrojasApiInfo", Version = "v1" }));

              services.ValidacionJwtServicesExtensions(Configuration);
                // services.AddSingleton<CacheProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RappiApiInfo v1");
                c.RoutePrefix = string.Empty;
            });

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
