using AutoMapper;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.DTO.Dtos.NotificationDtos;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDTO
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUSerDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Process-ProcessDto
            CreateMap<ProcessAddDto, Process>();
            CreateMap<Process, ProcessAddDto>();
            CreateMap<ProcessListAllDto, Process>();
            CreateMap<Process, ProcessListAllDto>();
            CreateMap<ProcessListDto, Process>();
            CreateMap<Process, ProcessListDto>();
            CreateMap<ProcessUpdateDto, Process>();
            CreateMap<Process, ProcessUpdateDto>();
            #endregion

            #region Report-ReportDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>(); 
            #endregion

        }
    }
}
