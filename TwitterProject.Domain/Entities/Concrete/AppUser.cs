using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TwitterProject.Domain.Entities.Interface;
using TwitterProject.Domain.Enums;

namespace TwitterProject.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        public AppUser() // İlgili varlığın initialize edildiğinde ilişkilerin otomatik olarak oluşturulması için consructor method içerisine yazdık. Ayrıca migrations işleminde kesintiler yaşanmamaktadır. Bunların önüne geçmek için yapıcı method içerisinden yapılır.
        {
            Tweets = new List<Tweet>();
            Likes = new List<Like>();
            Shares = new List<Share>();
            Mentions = new List<Mention>();

        }

        public string Name { get; set; }
        public string ImagePath { get; set; } = "/images/users/default.jpg";


        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => value = _createDate; }

        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => value = _status; }


        public List<Tweet> Tweets { get; set; }
        public List<Like> Likes { get; set; }
        public List<Share> Shares { get; set; }
        public List<Mention> Mentions { get; set; }

        [InverseProperty("Follower")]
        public List<Follow> Followers { get; set; } // Takipçilerim

        [InverseProperty("Following")]
        public List<Follow> Followings { get; set; }// Takip Ettiklerim
    }
}
