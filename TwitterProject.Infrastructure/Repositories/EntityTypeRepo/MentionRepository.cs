using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.Repositories.EntityTypeRepo;
using TwitterProject.Infrastructure.Context;
using TwitterProject.Infrastructure.Repositories.BaseRepo;

namespace TwitterProject.Infrastructure.Repositories.EntityTypeRepo
{
    public class MentionRepository : BaseRepository<Mention>, IMentionRepository
    {
        public MentionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
