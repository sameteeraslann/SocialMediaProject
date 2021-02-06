using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Domain.Repositories.EntityTypeRepo;
using TwitterProject.Domain.UnitOfWork;
using TwitterProject.Infrastructure.Context;
using TwitterProject.Infrastructure.Repositories.EntityTypeRepo;

namespace TwitterProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork // => IUnitOfWork'den implement yolu ile gövdelendireceğim methodlarımı aldım.
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) => this._db = db ?? throw new ArgumentNullException("Database Can Not To Be Null..!"); //=> ??= Karar mekanizmasını başlattık. Bu karar mekanizması ya bize db bağlantısını verecek ya da ArgumentNullException ile hata mesajımı gönderecektir.

        private IAppUserRepository _appRepository;
        public IAppUserRepository AppUserRepository
        {
            get
            {
                if (_appRepository == null) _appRepository = new AppUserRepository(_db); //=> _appRepository boş gelirse database bağlantısını üret.
                return _appRepository; //=> eğer dolu gelirse bağlı olan _appRepository yu bana geri ver
            }
        }

        private IFollowRepository _followRepository;
        public IFollowRepository FollowRepository
        {
            get
            {
                if (_followRepository == null) _followRepository = new FollowRepository(_db);
                return _followRepository;
            }
        }

        private ILikeRepository _likeRepository;
        public ILikeRepository LikeRepository
        {
            get
            {
                if (_likeRepository == null) _likeRepository = new LikeRepository(_db);
                return _likeRepository;
            }
        }

        private IMentionRepository _mentionRepository;
        public IMentionRepository MentionRepository
        {
            get
            {
                if (_mentionRepository == null) _mentionRepository = new MentionRepository(_db);
                return _mentionRepository;
            }
        }

        private IShareRepository _shareRepository;
        public IShareRepository ShareRepository
        {
            get
            {
                if (_shareRepository == null) _shareRepository = new ShareRepository(_db);
                return _shareRepository;
            }
        }

        private ITweetRepository _tweetRepository;
        public ITweetRepository TweetRepository
        {
            get
            {
                if (_tweetRepository == null) _tweetRepository = new TweetRepository(_db);
                return _tweetRepository;
            }
        }

        public async Task Commit() => await _db.SaveChangesAsync();

        public Task ExecuteSqlRaw(string sql, params object[] parameters) //=> Bu method içerisine sql sorgusu alacak ve execute edecek ve parameters gönderecek.
        {
            throw new NotImplementedException();
        }

        private bool isDisposing = false;
        public async ValueTask DisposeAsync()
        {
            if(!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);// Nesnemizi tamamıyla temizlenmesini sağlayack.
            }
        }
        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync(); // => Üretilen db nesnemizi dispose ettik.
        }
    }
}
