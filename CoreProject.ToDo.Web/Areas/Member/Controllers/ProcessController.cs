using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
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
    public class ProcessController : BaseIdentityController
    {
        private readonly IProcessService _processService;
        private readonly IMapper _mapper;
        public ProcessController(IProcessService processService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _processService = processService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = TempdataInfo.Process;
            var user = await GetLoggedInUser();
            var listmodel = _mapper.Map<List<ProcessListAllDto>>(_processService.GetCompletedProcessWithAllTables(out int totalPage, user.Id, activePage));
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;
            return View(listmodel);
        }
    }
}