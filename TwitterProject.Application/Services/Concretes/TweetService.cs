﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Models.VMs;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;

namespace TwitterProject.Application.Services.Concretes
{
    public class TweetService: ITweetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        private readonly IFollowService _followservice;

        public TweetService(IUnitOfWork unitOfWork,
                             IMapper mapper,
                            IAppUserService appUserService,
                            IFollowService followService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._appUserService = appUserService;
            this._followservice = followService;
        }

        public async Task AddTweet(AddTweetDTO addTweetDTO)
        {
            if (addTweetDTO.Image != null)
            {
                using var image = Image.Load(addTweetDTO.Image.OpenReadStream());
                if (image.Width > 600)
                {
                    image.Mutate(x => x.Resize(256, 256));
                }
                image.Save($"wwwroot/images/tweets/" + Guid.NewGuid().ToString() + ".jpg");
                addTweetDTO.ImagePath = ("/images/tweets/" + Guid.NewGuid().ToString() + ".jpg");
            }

            var tweet = _mapper.Map<AddTweetDTO, Tweet>(addTweetDTO);
            await _unitOfWork.TweetRepository.Add(tweet);
            await _unitOfWork.Commit();
        }

        public async Task DeleteTweet(int id, int userId)
        {
            var tweet = await _unitOfWork.TweetRepository.FirstOrDefault(x => x.Id == id);
            if (userId == tweet.Id)
            {
                _unitOfWork.TweetRepository.Delete(tweet);
                await _unitOfWork.Commit();
            }
        }

        public async Task<List<TimeLineVM>> GetTimeLine(int userId, int pageIndex)
        {
            List<int> followings = await _followservice.Followings(userId);

            var tweets = await _unitOfWork.TweetRepository.GetFilteredList(
                selector: x => new TimeLineVM
                {
                    Id = x.Id,
                    Text = x.Text,
                    ImagePath = x.ImagePath,
                    UserName = x.AppUser.UserName,
                    AppUserId = x.AppUserId,
                    UserProfilPicture = x.AppUser.ImagePath,
                    CreateDate = x.CreateDate,
                    isLiked = x.Likes.Any(x => x.AppUserId == userId),
                    LikeCount = x.Likes.Count,
                    MentionCount = x.Mentions.Count,
                    ShareCount = x.Shares.Count
                },
                expression: x => followings.Contains(userId),
                orderby: x => x.OrderByDescending(x => x.CreateDate),
                include: x => x.Include(x => x.AppUser)
                            .ThenInclude(x => x.Followings)
                            .Include(x => x.Likes),
                pageIndex: pageIndex
                );

            return tweets;
        }

        public async Task<List<TimeLineVM>> UserTweet(string userName, int pageIndex)
        {
            int user = await _appUserService.GetUserIdFromName(userName);

            var tweets = await _unitOfWork.TweetRepository.GetFilteredList(
               selector: x => new TimeLineVM
               {
                   Id = x.Id,
                   Text = x.Text,
                   ImagePath = x.ImagePath,
                   UserName = x.AppUser.UserName,
                   AppUserId = x.AppUserId,
                   UserProfilPicture = x.AppUser.ImagePath,
                   CreateDate = x.CreateDate,
                   isLiked = x.Likes.Any(x => x.AppUserId == user),
                   LikeCount = x.Likes.Count,
                   MentionCount = x.Mentions.Count,
                   ShareCount = x.Shares.Count
               },
               expression: x => x.AppUserId == user,
               orderby: x => x.OrderByDescending(x => x.CreateDate),
               include: x => x.Include(x => x.AppUser)
                           .ThenInclude(x => x.Followings)
                           .Include(x => x.Likes),
               pageIndex: pageIndex
               );

            return tweets;
        }
    }
    }
}
