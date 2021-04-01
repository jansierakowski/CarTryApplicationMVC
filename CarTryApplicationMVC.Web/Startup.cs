using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.Service;
using CarTryApplicationMVC.Infrastructure;
using CarTryApplicationMVC.Application;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using Microsoft.Extensions.Logging;
using CarTryApplicationMVC.Application.ViewModels.Ad;
using static CarTryApplicationMVC.Application.ViewModels.Ad.NewAdVm;

namespace CarTryApplicationMVC.Web
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
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews()
                .AddFluentValidation(fv=>fv.RunDefaultMvcValidationAfterFluentValidationExecutes= false);
            services.AddRazorPages();

            //services.AddTransient<IItemService, ItemService>();
            services.AddApplication();
            services.AddInfrastructure();
            services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();
            services.AddTransient<IValidator<NewAdVm>, NewAdValidation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/my-Log-{Date}.txt");
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
