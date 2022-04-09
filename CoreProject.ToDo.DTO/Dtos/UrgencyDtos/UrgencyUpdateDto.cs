using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.UrgencyDtos
{
    public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım")]
        //[Required(ErrorMessage = "Tanım alanı zorunludur.")]
        public string Definition { get; set; }
    }
}
