using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.ProcessDtos
{
   public class ProcessListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreateDate { get; set; }
        public Urgency Urgency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
