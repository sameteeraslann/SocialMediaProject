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
        private readonly IAppUserService _userService;
        public ProfileSummary(IAppUserService appUserService) => _userService = appUserService;

        //[Route("/ProfileSummary/", Name = "ProfileSummary")]
        public async Task<IViewComponentResult> InvokeAsync(string userName) => View(await _userService.GetByUserName(userName));
    }
}
//[Route("/Speaker/EvaluationsCurrent",
//Name = "speakerevalscurrent")]