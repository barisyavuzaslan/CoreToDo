using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context
{
    public class CoreToDoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I3V4BUE\\BARIS;Database=PROJECTTODO;User Id=sa;Password=123456;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Process> Processes { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
