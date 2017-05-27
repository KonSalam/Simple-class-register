using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.DataContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleClassRegisterApp.Models.Services;
using SimpleClassRegisterApp.Models.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace SimpleClassRegisterApp
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                                .AddEnvironmentVariables()
                                .AddJsonFile(env.ContentRootPath + "/config.json")
                                .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions =
                   configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });

            //DbContext
            services.AddDbContext<ClassRegisterDataContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("ClassRegisterDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<IdentityDataContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("IdentityDataContext");
                options.UseSqlServer(connectionString);
            });

            //Identity Options
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<IdentityDataContext>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Cookies.ApplicationCookie.LoginPath = new PathString("/Home/IdentityError");
                opt.Cookies.ApplicationCookie.AccessDeniedPath = new PathString("/Home/IdentityError");
            });

            //Services DI
            services.AddTransient<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, FeatureToggles features, RoleManager<IdentityRole> roleManager)
        {
            loggerFactory.AddConsole();
            app.UseExceptionHandler("/Home/Error");

            if (features.EnableDeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseFileServer();

            RolesData.CreateRoles(roleManager).Wait();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("ERROR!");

                await next();
            });
        }
    }
}