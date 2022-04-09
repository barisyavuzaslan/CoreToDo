using System.Collections.Generic;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProject.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ProcessController : Controller
    {
        private readonly IProcessService _processService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public ProcessController(IProcessService processService, IUrgencyService urgencyService, IMapper mapper)
        {
            _processService = processService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Process;
            return View(_mapper.Map<List<ProcessListDto>>(_processService.GetWithUrgencyAndNotCompleted()));
        }
        public IActionResult AddProcess()
        {
            TempData["Active"] = TempdataInfo.Process;
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition");
            return View(new ProcessAddDto());
        }
        [HttpPost]
        public IActionResult AddProcess(ProcessAddDto model)
        {
            if (ModelState.IsValid)
            {
                _processService.Save(new Process()
                {
                    Name = model.Name,
                    Desc = model.Desc,
                    UrgencyId = model.UrgencyId

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateProcess(int id)
        {
            TempData["Active"] = TempdataInfo.Process;
            var gorev = _processService.GetWithID(id);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition", gorev.UrgencyId);
            return View(_mapper.Map<ProcessUpdateDto>(gorev));
        }
        [HttpPost]
        public IActionResult UpdateProcess(ProcessUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _processService.Update(new Process()
                {
                    Id = model.Id,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId,
                    Desc = model.Desc
                });
                return RedirectToAction("Index");
            }
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Definition", model.UrgencyId);
            return View();
        }


        public IActionResult DeleteProcess(int id)
        {
            _processService.Delete(new Process()
            {
                Id = id
            });

            return Json(null);
        }

    }
}