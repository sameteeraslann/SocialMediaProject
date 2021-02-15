using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Models.VMs;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;

namespace TwitterProject.Application.Services.Concretes
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFollowService _followService;

        public AppUserService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              IFollowService followService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._followService = followService;
        }

        public async Task DeleteUser(params object[] parameters) => await _unitOfWork.ExecuteSqlRaw($"spDeleteUsers {0}", parameters);
        // params object[] => Değişken türü belli olmayan durumlarda C# içerisindeki her şeyin object türünden türediği özelliği kullanılabilir.


        public async Task EditUser(EditProfileDTO model)
        {
            var user = await _unitOfWork.AppUserRepository.GetById(model.Id);
            if (user != null)
            {
                if (model.Image != null)
                {
                    using var image = Image.Load(model.Image.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save("wwwroot/images/users/" + user.UserName + ".jpg");
                    user.ImagePath = ("/images/users/" + user.UserName + ".jpg");
                    _unitOfWork.AppUserRepository.Update(user);
                    await _unitOfWork.Commit();
                }

                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }
                if (model.UserName != user.UserName)
                {
                    var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);

                    if (isUserNameExist == null)
                    {
                        await _userManager.SetUserNameAsync(user, model.UserName);
                        user.UserName = model.UserName;
                        await _signInManager.SignInAsync(user, isPersistent: true);
                    }
                }
                if (model.Name != user.Name)
                {
                    user.Name = model.Name;
                    _unitOfWork.AppUserRepository.Update(user);
                    await _unitOfWork.Commit();
                }
                if (model.Email != user.Email)
                {
                    var isEmailExist = await _userManager.FindByEmailAsync(model.Email);
                    if (isEmailExist == null)
                        await _userManager.SetEmailAsync(user, model.Email);
                }

            }
        }

        public async Task<EditProfileDTO> GetById(int id)
        {
            var user = await _unitOfWork.AppUserRepository.GetById(id);

            return _mapper.Map<EditProfileDTO>(user);
        }


        public async Task<ProfileSummaryDTO> GetByUserName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
               selector: y => new ProfileSummaryDTO
               {
                   UserName = y.UserName,
                   Name = y.Name,
                   ImagePath = y.ImagePath,
                   TweetCount = y.Tweets.Count,
                   FollowerCount = y.Followers.Count,
                   FollowingCount = y.Followings.Count
               },
               expression: x => x.UserName == userName);

            return user;
        }

        public async Task<int> GetUserIdFromName(string name)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id, // Entity de olan Id yi bize getirdi.
                expression: x => x.Name == name // dışarıdan gelen name ile DB de var mı yok mu diye kontrol etti.
                );
            return user;
        }

        public async Task<SignInResult> LogIn(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.Rememberme, false);

            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<AppUser>(registerDTO);

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded) await _signInManager.SignInAsync(user, isPersistent: false);// isPersistent => Çerez hatırlansın mı ?

            return result;
        }
        public async Task<int> UserIdFromName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id,
                expression: x => x.UserName == userName);

            return user;
        }
        public async Task<List<FollowListVM>> UsersFollowings(int id, int pageIndex)
        {

            List<int> followings = await _followService.Followings(id);

            var followingsList = await _unitOfWork.AppUserRepository.GetFilteredList(selector: y => new FollowListVM
            {
                Id = y.Id,
                ImagePath = y.ImagePath,
                UserName = y.UserName,
                Name = y.Name,
            },
                expression: x => followings.Contains(x.Id),
                include: x => x
               .Include(z => z.Followers),
                pageIndex: pageIndex);
            return followingsList;

        }
        public async Task<List<FollowListVM>> UsersFollowers(int id, int pageIndex)
        {

            List<int> followers = await _followService.Followers(id);

            var followersList = await _unitOfWork.AppUserRepository.GetFilteredList(selector: y => new FollowListVM
            {
                Id = y.Id,
                ImagePath = y.ImagePath,
                UserName = y.UserName,
                Name = y.Name,
            },
                expression: x => followers.Contains(x.Id),
                include: x => x
               .Include(z => z.Followers),
                pageIndex: pageIndex);
            return followersList;

        }
        public async Task<List<SearchUserDTO>> SearchUser(string keyword, int pageIndex)
        {
            var users = await _unitOfWork.AppUserRepository.GetFilteredList(
                selector: x => new SearchUserDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName,
                    ImagePath = x.ImagePath
                },
                expression: x => x.UserName.Contains(keyword) || x.Name.Contains(keyword),
                pageIndex: pageIndex, pageSize: 10);

            return users;
        }
    }
}



