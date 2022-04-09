using CoreProject.ToDo.BusinessLayer.Concrete;
using CoreProject.ToDo.BusinessLayer.CustomLogger;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProcessService, ProcessManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IFileService, FileManager>();

            services.AddScoped<IProcessDal, EfProcessRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
