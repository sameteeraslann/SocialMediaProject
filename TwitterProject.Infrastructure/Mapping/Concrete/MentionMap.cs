using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Infrastructure.Mapping.Abstract;

namespace TwitterProject.Infrastructure.Mapping.Concrete
{
    public class MentionMap : BaseMap<Mention>
    {
        public override void Configure(EntityTypeBuilder<Mention> builder)
        {
            builder.HasKey(x => new { x.Id, x.AppUserId, x.TweetId });

            builder.Property(x => x.Text).IsRequired(false);

            base.Configure(builder);
        }
    }
}
