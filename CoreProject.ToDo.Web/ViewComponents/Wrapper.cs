using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProject.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {

            var identitiyuser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(_userManager.FindByNameAsync(User.Identity.Name).Result);

            var notificationcount = _notificationService.GetNotReads(identitiyuser.Id).Count();
            ViewBag.NotCount = notificationcount;
            var roles = _userManager.GetRolesAsync(identitiyuser).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }

            return View("Member", model);


        }
    }
}
