using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.ProcessDtos
{
    public class ProcessListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }


        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
