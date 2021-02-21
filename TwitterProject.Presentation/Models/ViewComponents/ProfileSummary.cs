using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterProject.Application.Services.Interfaces;

namespace TwitterProject.Presentation.Models.ViewComponents
{
    public class ProfileSummary: ViewComponent
    {
        private readonly IAppUserService _appUserService;

        public ProfileSummary(IAppUserService appUserService) => this._appUserService = appUserService;

        public async Task<IViewComponentResult> InvokeAsync(string userName) => View(await _appUserService.GetByUserName(userName));
    }
}
