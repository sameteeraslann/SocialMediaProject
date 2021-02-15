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
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService) => this._followService = followService;

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Follow(FollowDTO model)
        {
            if (!model.isExsist)
            {
                if (model.FollowerId == User.GetUserId())
                {
                    await _followService.Follow(model);
                    return Json("Success");
                }
                else return Json("Faild");
            }
            else
            {
                if (model.FollowerId == User.GetUserId())
                {
                    await _followService.UnFollow(model);
                    return Json("Success");
                }
                else return Json("Faild");

            }
        }
    }
}
