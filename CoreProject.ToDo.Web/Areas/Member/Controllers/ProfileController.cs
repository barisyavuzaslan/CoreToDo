using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.BaseControllers;
using CoreProject.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Profile;
            var appuser = await GetLoggedInUser();
            return View(_mapper.Map<AppUserListDto>(appuser));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var uUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimName = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }
                    uUser.Picture = resimName;
                }
                uUser.Name = model.Name;
                uUser.Surname = model.Surname;
                uUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(uUser);

                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
                    return RedirectToAction("Index");
                }

                AddError(result.Errors);

            }

            return View(model);
        }
    }
}