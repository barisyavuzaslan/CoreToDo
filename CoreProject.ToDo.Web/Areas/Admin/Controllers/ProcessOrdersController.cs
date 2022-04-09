using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ProcessOrdersController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IProcessService _processService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public ProcessOrdersController(IAppUserService appUserService, IProcessService processService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _processService = processService;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] =TempdataInfo.ProcessOrders;
            return View(_mapper.Map<List<ProcessListAllDto>>(_processService.GetWithTables()));
        }

        public IActionResult AssignStaff(int id, string s, int page = 1)
        {
            TempData["Active"] = TempdataInfo.ProcessOrders;
            ViewBag.ActivePage = page;
            ViewBag.Searching = s;
            var personals = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNoContentAdmin(out int totalPage, s, page));
            ViewBag.TotalPage = totalPage;
            ViewBag.Personals = personals;
            return View(_mapper.Map<ProcessListDto>(_processService.GetProcessWithUrgencyAndId(id)));

        }

        [HttpPost]
        public IActionResult AssignStaff(AssignStaffDto model)
        {
            var uprocess = _processService.GetWithID(model.ProcessId);
            uprocess.AppUserId = model.UserId;
            _processService.Update(uprocess);

            _notificationService.Save(new Notification()
            {
                AppUserId = model.UserId,
                Description = $"{uprocess.Name } adlı iş için görevlendirildiniz."
            });
            return RedirectToAction("Index");
        }

        public IActionResult AssignPersonal(AssignStaffDto model)
        {
            TempData["Active"] = TempdataInfo.ProcessOrders;
            var user = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.UserId));
            var process = _mapper.Map<ProcessListDto>(_processService.GetProcessWithUrgencyAndId(model.ProcessId));
            AssignStaffListDto assignStaffModel = new AssignStaffListDto
            {
                appUser = user,
                process = process
            };
            return View(assignStaffModel);
        }


        public IActionResult GetDetails(int id)
        {

            TempData["Active"] = TempdataInfo.ProcessOrders;
            return View(_mapper.Map<ProcessListAllDto>(_processService.GetReportsWithProcessId(id)));
        }
        public IActionResult GetExcel(int id)
        {
            var raporlar = _processService.GetReportsWithProcessId(id).Reports.ToList();
            return File(_fileService.TransferExcel(raporlar), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }
        public IActionResult GetPdf(int id)
        {
            var path = _fileService.TransferExcel(_processService.GetReportsWithProcessId(id).Reports.ToList());
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}