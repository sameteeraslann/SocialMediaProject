using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.Domain.Entities.Concrete
{
    public class Tweet : BaseEntity<int>
    {
        public Tweet()
        {
            Likes = new List<Like>();
            Shares = new List<Share>();
            Mentions = new List<Mention>();
        }

        public string Text { get; set; }
        public string ImagePath { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Like> Likes { get; set; }
        public List<Share> Shares { get; set; }
        public List<Mention> Mentions { get; set; }
    }
}
