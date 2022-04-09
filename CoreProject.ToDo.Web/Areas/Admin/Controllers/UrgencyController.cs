using System.Collections.Generic;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Urgency;
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = TempdataInfo.Urgency;
            return View(new UrgencyAddDto());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency()
                {
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = TempdataInfo.Urgency;           
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetWithID(id)));
        }
        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency()
                {
                    Definition = model.Definition,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}