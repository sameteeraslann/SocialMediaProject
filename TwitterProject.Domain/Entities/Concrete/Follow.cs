using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TwitterProject.Domain.Entities.Interface;
using TwitterProject.Domain.Enums;

namespace TwitterProject.Domain.Entities.Concrete
{
    public class Follow : BaseEntity<int>
    {
        public int FollowerId { get; set; }
        [ForeignKey("FollowerId"), InverseProperty("Followers")]
        public AppUser Follower { get; set; }

        public int FollowingId { get; set; }
        [ForeignKey("FollowingId"), InverseProperty("Followings")]
        public AppUser Following { get; set; }


    }
}
