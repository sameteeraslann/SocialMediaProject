using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterProject.Application.Services.Interfaces;

namespace TwitterProject.Presentation.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAppUserService _userService;
        public SearchController(IAppUserService appUserService) => this._userService = appUserService;


        public IActionResult Index(string userName)
        {
            ViewBag.SearchKeyword = userName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userName, int pageIndex)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                var users = await _userService.SearchUser(userName, pageIndex);

                return Json(users, new JsonSerializerSettings());
            }
            else return NotFound();
        }
    }
}
