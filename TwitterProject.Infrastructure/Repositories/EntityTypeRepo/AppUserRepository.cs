﻿using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.Repositories.EntityTypeRepo;
using TwitterProject.Infrastructure.Context;
using TwitterProject.Infrastructure.Repositories.BaseRepo;

namespace TwitterProject.Infrastructure.Repositories.EntityTypeRepo
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository // => BaseRepository<AppUser> tipinde kalıtım aldık. Daha sonra inject edeceğimiz IAppUserRepository tanımladık. Bunu yapmamızın amacı DIP prensibine uymamız. Sınıfları olabildiğince birbirinden bağımsız hale getirmek.
    {
        public AppUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { } //=> Database bağlantısını yaptık.
    }
}
