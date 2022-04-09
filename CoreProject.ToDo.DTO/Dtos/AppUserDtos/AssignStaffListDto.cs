using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.AppUserDtos
{
    public class AssignStaffListDto
    {
        public AppUserListDto appUser { get; set; }
        public ProcessListDto process { get; set; }
    }
}
