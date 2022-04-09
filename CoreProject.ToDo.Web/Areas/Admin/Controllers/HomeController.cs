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

namespace CoreProject.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IProcessService _processService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;
        public HomeController(IProcessService processService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService) : base(userManager)
        {
            _processService = processService;
            _notificationService = notificationService;
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Home;
            var user = GetLoggedInUser();
            ViewBag.NotAssignProcessCount = _processService.NotAsssignProcessCount();
            ViewBag.CompletedProcess = _processService.GetCompletedProcessCount();
            ViewBag.NotReadNotificationCount = _notificationService.NotReadNotificationWithAppUserId(user.Id);
            ViewBag.ReportCount = _reportService.GetAllReportCount();
            return View();
        }
    }
}