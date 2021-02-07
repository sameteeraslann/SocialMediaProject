using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Models.VMs;

namespace TwitterProject.Application.Services.Interfaces
{
    public interface ITweetService
    {
        Task<List<TimeLineVM>> GetTimeLine(int userId, int pageIndex);
        Task AddTweet(AddTweetDTO addTweetDTO);
        Task<List<TimeLineVM>> UserTweet(string userName, int pageIndex);
        Task DeleteTweet(int id, int userId);
    }
}
