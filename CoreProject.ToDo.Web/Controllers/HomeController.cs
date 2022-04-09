using System;
using System.Threading.Tasks;
using AutoMapper;
using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using CoreProject.ToDo.Web.BaseControllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _customLogger;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomLogger customLogger) : base(userManager)
        {
            _signInManager = signInManager;
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identitiyResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identitiyResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        if (roles.Contains("Member"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }

                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalıdır.");
            }

            return View("Index", model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            AppUser appUser = new AppUser()
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email
            };

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(appUser, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    AddError(addRoleResult.Errors);

                }
                AddError(result.Errors);
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa Bulunamadı";
            }
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Hatanın oluştuğu yer:{exceptionHandler.Path}\nHatanın mesajı: {exceptionHandler.Error.Message}\nStack Trace :{exceptionHandler.Error.StackTrace}");
            return View();
        }



    }
}