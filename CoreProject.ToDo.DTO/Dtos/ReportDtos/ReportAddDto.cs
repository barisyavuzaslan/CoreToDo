using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.ReportDtos
{
   public class ReportAddDto
    {
        //[Display(Name = "Tanım :")]
        //[Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Definition { get; set; }
        //[Display(Name = "Detay :")]
        //[Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Details { get; set; }
        public Process Process { get; set; }
        public int ProcessId { get; set; }
    }
}
