using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.Application.Models.DTOs
{
   public class LikeDTO
    {
        public int AppUserId { get; set; }
        public int TweetId { get; set; }
        public int isExsist { get; set; }
    }
}
