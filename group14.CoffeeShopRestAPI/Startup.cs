using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoffeeShop.Infrastructure.Data.Repositories;
using CoffeeShop.Core.Entities;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.ApplicationService;
using Newtonsoft.Json;
using CoffeeShop.Core;
using CoffeeShop.Core.ApplicationService.Impl;

namespace group14.CoffeeShopRestAPI
{
    public class Startup
    {

        public IConfiguration _conf { get; }

        public IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_env.IsDevelopment())
            {
                services.AddDbContext<CoffeeContext>(
                opt => opt.UseSqlite("Data Source=CoffeeShop.db"));
            }
            //For SQLite DB.. Needs actual lists and tables
            //ConnectionString fra Azure (Online)
            else if (_env.IsProduction())
            {
                services.AddDbContext<CoffeeContext>(
                    opt => opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            //dependency injection
            //Copied from Program 
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();

            services.AddScoped<ICoffeeService, CoffeeService>();

            //For Ignoring Loop References
            services.AddMvc().AddJsonOptions(Options => {
                Options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
            services.AddCors(options =>
            {
                /*
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://coffeeshopproject.azurewebsites.net/api/coffee").AllowAnyHeader()
                        .AllowAnyMethod());
                        */
                        
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //for database on startup
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CoffeeContext>();

                    DBSeeder.SeedTheDB(ctx);
                }

            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CoffeeContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }
            // Shows UseCors with named policy.
            //app.UseCors("AllowSpecificOrigin");
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
