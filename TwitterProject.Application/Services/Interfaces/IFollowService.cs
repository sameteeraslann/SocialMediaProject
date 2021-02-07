using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;

namespace TwitterProject.Application.Services.Interfaces
{
    public interface IFollowService
    {
        Task Follow(FollowDTO followDTO);
        Task UnFollow(FollowDTO followDTO);

        Task<bool> IsFollowing(FollowDTO followDTO);

        Task<List<int>> Followers(int id);
        Task<List<int>> Followings(int id);
    }
}
