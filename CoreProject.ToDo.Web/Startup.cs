using CoreProject.ToDo.BusinessLayer.Concrete;
using CoreProject.ToDo.BusinessLayer.DiContainer;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.CustomCollectionExtensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CoreProject.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddContainerWithDependencies();
            services.AddDbContext<CoreToDoContext>();
            services.AddCustomIdentity();

            services.AddAutoMapper(typeof(Startup));
            services.AddCustomValidator();

            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
