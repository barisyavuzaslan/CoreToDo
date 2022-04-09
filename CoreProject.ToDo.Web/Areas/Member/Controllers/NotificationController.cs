using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.NotificationDtos;
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
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Notification;
            var user = await GetLoggedInUser();
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetNotReads(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var gnotfication = _notificationService.GetWithID(id);
            gnotfication.Status = true;
            _notificationService.Update(gnotfication);

            return RedirectToAction("Index");
        }
    }
}