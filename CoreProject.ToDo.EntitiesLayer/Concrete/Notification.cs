using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.EntitiesLayer.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
