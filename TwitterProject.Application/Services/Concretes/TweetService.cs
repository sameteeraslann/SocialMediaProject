using AutoMapper;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
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

        public TweetService(IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
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

        public Task DeleteTweet(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TimeLineVM>> GetTimeLine(int userId, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public Task<List<TimeLineVM>> UserTweet(string userName, int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}
