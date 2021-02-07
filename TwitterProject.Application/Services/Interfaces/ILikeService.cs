using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;

namespace TwitterProject.Application.Services.Interfaces
{
    public interface ILikeService
    {
        Task Like(LikeDTO likeDTO);
        Task UnLike(LikeDTO likeDTO);
    }
}
