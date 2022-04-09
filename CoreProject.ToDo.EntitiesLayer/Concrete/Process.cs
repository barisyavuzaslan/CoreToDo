using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreProject.ToDo.EntitiesLayer.Concrete
{
    public class Process : ITable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;


        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }


    }
}
