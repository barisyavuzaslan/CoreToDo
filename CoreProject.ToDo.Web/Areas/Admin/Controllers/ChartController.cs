using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ChartController : Controller
    {
        private readonly IAppUserService _appUserService;
        public ChartController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Chart;
            return View();
        }

        public IActionResult MaxCompletedProcess()
        {
            var jsonstring = JsonConvert.SerializeObject(_appUserService.GetMaxCompletedProcessWithPersonels());
            return Json(jsonstring);
        }
        public IActionResult MaxWorkProcess()
        {
            var jsonstring = JsonConvert.SerializeObject(_appUserService.GetMaxWorkTheProcessWithPersonels());
            return Json(jsonstring);
        }
    }
}