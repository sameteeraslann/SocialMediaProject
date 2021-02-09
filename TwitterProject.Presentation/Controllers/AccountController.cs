using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterProject.Application.Extensions;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Interfaces;

namespace TwitterProject.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        #region Register
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(registerDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors) ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(registerDTO);
        }
        #endregion

        #region Login
        public IActionResult Login (string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction(nameof(HomeController.Index), "Home");

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginDTO loginDTO,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.LogIn(loginDTO);
                if (result.Succeeded) return RedirectToLocal(returnUrl);
            }
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))  return Redirect(returnUrl);
            
            else return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion

        #region LogOut
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion

        #region EditProfile
        public async Task<IActionResult> EditProfile(string userName)
        {
            if (userName == User.Identity.Name)
            {
                var user = await _appUserService.GetById(User.GetUserId());

                if (user == null) return NotFound();

                return View(user);
            }
            else return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public async Task <IActionResult> EditProfile (EditProfileDTO editProfileDTO,IFormFile file)
        {
            editProfileDTO.Image = file;

            await _appUserService.EditUser(editProfileDTO);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #endregion
    }
}
