using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Interface;
using TwitterProject.Domain.Enums;

namespace TwitterProject.Domain.Entities.Concrete
{
    public class Mention :BaseEntity<int>
    {
        public string Text { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }

    }
}
