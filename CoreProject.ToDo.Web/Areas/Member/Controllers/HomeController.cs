using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.ToDo.BusinessLayer.Interfaces;
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
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IProcessService _processService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IProcessService processService, INotificationService notificationService) : base(userManager)
        {

            _reportService = reportService;
            _processService = processService;
            _notificationService = notificationService;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Home;
            var user = await GetLoggedInUser();
            ViewBag.ReportCount = _reportService.GetReportCountWithAppUserId(user.Id);
            ViewBag.CompletedProcessCount = _processService.GetProcessCountCompletedWithAppUserId(user.Id);
            ViewBag.NotCompletedProcessCount = _processService.GetProcessNotCompletedWithAppUserId(user.Id);
            ViewBag.NotReadNotificationCount = _notificationService.NotReadNotificationWithAppUserId(user.Id);
            return View();
        }
    }
}