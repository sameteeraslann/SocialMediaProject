using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Domain.Repositories.EntityTypeRepo;

namespace TwitterProject.Domain.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IAppUserRepository AppUserRepository { get; }
        IFollowRepository FollowRepository { get; }
        ILikeRepository LikeRepository { get; }
        IMentionRepository MentionRepository { get; }
        IShareRepository ShareRepository { get; }
        ITweetRepository TweetRepository { get; }

        Task Commit();// => Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başalamasından itibaren tüm değişikliklerin veri tabanına uyhulanmasını temin eder.

        Task ExecuteSqlRaw(string sql, params object[] parameters); //Mevcut sql sorgularımızı doğrudan veritabanında yürütmek için kullanılan bir methoddur.

    }
}
