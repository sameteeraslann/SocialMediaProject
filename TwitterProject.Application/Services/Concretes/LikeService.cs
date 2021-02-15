using AutoMapper;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;

namespace TwitterProject.Application.Services.Concretes
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Like(LikeDTO likeDTO)
        {
            var isLiked = await _unitOfWork.LikeRepository.FirstOrDefault(x => x.AppUserId == likeDTO.AppUserId && x.TweetId == likeDTO.TweetId);
            if (isLiked == null)
            {
                var like = _mapper.Map<LikeDTO, Like>(likeDTO);
                await _unitOfWork.LikeRepository.Add(like);
                await _unitOfWork.Commit();
            }
        }

        public async Task UnLike(LikeDTO likeDTO)
        {
            var isLiked = await _unitOfWork.LikeRepository.FirstOrDefault(x => x.AppUserId == likeDTO.AppUserId && x.TweetId == likeDTO.TweetId);
            _unitOfWork.LikeRepository.Delete(isLiked);
            await _unitOfWork.Commit();
        }
    }
}
