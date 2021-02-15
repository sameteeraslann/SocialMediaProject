using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterProject.Application.Extensions;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Interfaces;

namespace TwitterProject.Presentation.Controllers
{
    public class TweetController : Controller
    {
        private readonly ITweetService _tweetService;

        public TweetController(ITweetService tweetService) => this._tweetService = tweetService;

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> AddTweet(AddTweetDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model.AppUserId == User.GetUserId())
                {
                    await _tweetService.AddTweet(model);
                    return Json("Success");
                }
                else return Json("Faild");
            }
            else return BadRequest(String.Join(Environment.NewLine, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage + " " + x.Exception)));
        }

        [HttpPost]
        public async Task<IActionResult> GetTweets(int pageIndex, int pageSize, string userName = null)
        {
            if (userName == null) return Json(await _tweetService.GetTimeLine(User.GetUserId(), pageIndex), new JsonSerializerSettings());
            else return Json(await _tweetService.UserTweets(userName, pageIndex));
        }


    }
}
