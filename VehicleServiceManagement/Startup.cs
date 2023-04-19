using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VehicleServiceManagement.Areas.Complaints.Data;
using VehicleServiceManagement.Areas.Report.Data;
using VehicleServiceManagement.Areas.Service.Data;
using VehicleServiceManagement.Areas.VehicleDetail.Data;
using VehicleServiceManagement.Data;
using VehicleServiceManagement.Models;
using VehicleSeviceManagement.DbEngine;

namespace VehicleServiceManagement
{
    public class Startup
    {   
        /// <summary>
        /// Constructor of startup method
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Declaring an object of IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Injecting the Repository and interface
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IComplaintsRepository, ComplaintsRepository>();
            services.AddSingleton<IServiceRepository, ServiceRepository>();
            services.AddSingleton<IVehicleDetailRepository, VehicleDetailRepository>();
            services.AddSingleton<ISqlServerHanlder, SQLServerHandler>();
            services.AddSingleton<IReportRepository, ReportRepository>();
            // Add serivce for Session
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(180);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;

            });

            //To configure Db context
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "Vehicle",
                  template: "{area:exists}/{controller=Vehicle}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vehicle}/{action=Registertion}/{id?}");
            });
        }
    }
}
