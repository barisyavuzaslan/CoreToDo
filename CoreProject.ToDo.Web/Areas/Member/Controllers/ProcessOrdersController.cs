using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.BaseControllers;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class ProcessOrdersController : BaseIdentityController
    {
        private readonly IProcessService _processService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public ProcessOrdersController(UserManager<AppUser> userManager, IProcessService processService, IReportService reportService, INotificationService notificationService, IMapper mapper) : base(userManager)
        {
            _processService = processService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.InCommingWorks;
            var user = await GetLoggedInUser();
            return View(_mapper.Map<List<ProcessListAllDto>>(_processService.GetWithTables(I => I.AppUserId == user.Id && !I.Status)));
        }

        public IActionResult AddReport(int id)
        {

            TempData["Active"] = TempdataInfo.InCommingWorks;
            var gorev = _processService.GetProcessWithUrgencyAndId(id);
            ReportAddDto model = new ReportAddDto
            {
                ProcessId = id,
                Process = gorev
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    Definition = model.Definition,
                    Details = model.Details,
                    ProcessId = model.ProcessId
                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await GetLoggedInUser();
                foreach (var admin in adminUserList)
                {
                    _notificationService.Save(new Notification()
                    {
                        Description = $"{activeUser.Name} {activeUser.Surname} yeni bir rapor yazdı",
                        AppUserId = admin.Id

                    });
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult EditReport(int id)
        {
            TempData["Active"] = TempdataInfo.InCommingWorks;
            var report = _reportService.GetProcessWithReportId(id);
            ReportUpdateDto model = new ReportUpdateDto()
            {
                Definition = report.Definition,
                Details = report.Details,
                Id = report.Id,
                Process = report.Process


            };
            return View(model);

        }
        [HttpPost]
        public IActionResult EditReport(ReportUpdateDto model)
        {

            if (ModelState.IsValid)
            {
                var guncellenecekrapor = _reportService.GetWithID(model.Id);
                guncellenecekrapor.Definition = model.Definition;
                guncellenecekrapor.Details = model.Details;
                _reportService.Update(guncellenecekrapor);
                return RedirectToAction("Index");

            }
            return View(model);

        }

        public async Task<IActionResult> CompletedTask(int id)
        {
            var uprocess = _processService.GetWithID(id);
            uprocess.Status = true;
            _processService.Update(uprocess);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await GetLoggedInUser();
            foreach (var admin in adminUserList)
            {
                _notificationService.Save(new Notification()
                {
                    Description = $"{activeUser.Name} {activeUser.Surname} vermiş olduğunuz görevi tamamladı",
                    AppUserId = admin.Id

                });
            }

            return Json(null);
        }
    }
}