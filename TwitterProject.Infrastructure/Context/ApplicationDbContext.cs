using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Infrastructure.Mapping.Concrete;

namespace TwitterProject.Infrastructure.Context
{
    public class ApplicationDbContext: IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){} // =>  "DB bağlantısını concructor method ile oluşturuldu."

        // Tabloları tek tek DbSet ile DataBase'ye gönderileceği için onları hazırlacağım.

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

     
        // Şimdi yaptığımız Map'leme işlemini override edeceğiz.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TweetMap());
            builder.ApplyConfiguration(new MentionMap());
            builder.ApplyConfiguration(new ShareMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new FollowMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new AppRoleMap());
            base.OnModelCreating(builder);
        }
    }
}
