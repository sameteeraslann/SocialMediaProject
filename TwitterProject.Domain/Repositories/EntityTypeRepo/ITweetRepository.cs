using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.Repositories.BaseRepo;

namespace TwitterProject.Domain.Repositories.EntityTypeRepo
{
    public interface ITweetRepository : IRepository<Tweet> { }
}
