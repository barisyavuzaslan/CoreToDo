using CoreProject.ToDo.EntitiesLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.EntitiesLayer.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Notification> Notifications { get; set; }
        public List<Process> Processes { get; set; }
    }
}
