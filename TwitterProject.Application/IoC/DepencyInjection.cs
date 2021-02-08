using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Application.Mapper;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Concretes;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Application.Validations;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;
using TwitterProject.Infrastructure.Context;
using TwitterProject.Infrastructure.UnitOfWork;

namespace TwitterProject.Application.IoC
{
    public static class DepencyInjection
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMentionService, MentionService>();
            services.AddScoped<ITweetService, TweetService>();

            //Validation Resolver
            services.AddTransient<IValidator<RegisterDTO>, RegisterValidation>();
            services.AddTransient<IValidator<LoginDTO>, LoginValidation>();
            services.AddTransient<IValidator<AddTweetDTO>, TweetValidation>();

            services.AddIdentity<AppUser, AppRole>(x => //bağımlı olan sınıflarımızı register ettik sonrada resolve ediyoruz. ayarlarınıda manage ettik.
            {
                x.SignIn.RequireConfirmedAccount = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.User.RequireUniqueEmail = false;
                x.Password.RequiredLength = 3;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
