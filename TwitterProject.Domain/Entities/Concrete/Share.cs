using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.Domain.Entities.Concrete
{
    public class Share : BaseEntity<int>
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
