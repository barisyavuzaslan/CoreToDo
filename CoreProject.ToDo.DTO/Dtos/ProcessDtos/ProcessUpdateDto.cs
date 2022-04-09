using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.ProcessDtos
{
    public class ProcessUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Görev tanımı gereklidir.")]
        public string Name { get; set; }
        public string Desc { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz")]
        public int UrgencyId { get; set; }

    }
}
