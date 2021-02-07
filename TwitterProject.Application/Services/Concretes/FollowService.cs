using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;

namespace TwitterProject.Application.Services.Concretes
{
    public class FollowService : IFollowServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FollowService(IUnitOfWork unitOfWork,
                             IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task Follow(FollowDTO followDTO)// Böyle bir follow var mı yok mu onu kontrol etti bu follow yoksa follow'ların arasına ekle.
        {
            var isFollowExsist = await _unitOfWork.FollowRepository.FirstOrDefault(x => x.FollowerId == followDTO.FollowerId);

            if(isFollowExsist == null)
            {
                var follow = _mapper.Map<FollowDTO, Follow>(followDTO);
                await _unitOfWork.FollowRepository.Add(follow);
                await _unitOfWork.Commit();
            }
        }

        public async Task<List<int>> Followers(int id)
        {
            var followList = await _unitOfWork.FollowRepository.GetFilteredList(
                selector: x => x.FollowerId,
                expression: x => x.FollowerId == id
                );

            return followList;
        }

        public async Task<List<int>> Followings(int id)
        {
            var followingList = await _unitOfWork.FollowRepository.GetFilteredList(
                
                selector: x=> x.FollowingId,
                expression: x=> x.FollowingId == id
                );

            return followingList;
        }

        public async Task<bool> IsFollowing(FollowDTO followDTO)
        {
            var isFollowExsist = await _unitOfWork.FollowRepository.Any(x => x.FollowerId == followDTO.FollowerId && x.FollowingId == followDTO.FollowingId);

            return isFollowExsist;
        }

        public async Task UnFollow(FollowDTO followDTO)
        {
            var isFollowExsist = await _unitOfWork.FollowRepository.FirstOrDefault(x => x.FollowerId == followDTO.FollowerId);

            if (isFollowExsist == null)
            {
                var follow = _mapper.Map<FollowDTO, Follow>(followDTO);
                _unitOfWork.FollowRepository.Delete(follow);
                await _unitOfWork.Commit();
            }
        }
    }
}
