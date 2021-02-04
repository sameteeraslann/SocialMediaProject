using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Infrastructure.Mapping.Abstract;

namespace TwitterProject.Infrastructure.Mapping.Concrete
{
    public class AppRoleMap : BaseMap<AppRole> // => BaseMap'den kalıtım alması için ata sınıf olarak eklendi ve tipini "AppUser" dedik.
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
        }
    }
}
