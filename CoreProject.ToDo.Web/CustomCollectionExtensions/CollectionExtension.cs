using CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreProject.ToDo.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<CoreToDoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "TodoCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<ProcessAddDto>, ProcessAddValidator>();
            services.AddTransient<IValidator<ProcessUpdateDto>, ProcessUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
        }
    }
}
