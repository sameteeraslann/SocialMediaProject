using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Models.VMs;

namespace TwitterProject.Application.Services.Interfaces
{
    public interface IAppUserServices
    {
        Task DeleteUser(params object[] parameters);
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<SignInResult> LogIn(LoginDTO loginDTO);
        Task LogOut();

        Task<int> GetUserIdFromName(string name); //İsminden kullanıcının Id getir.
        Task<EditProfileDTO> GetById(int id);
        Task EditUser(EditProfileDTO editProfileDTO);
        Task<ProfileSummaryDTO> GetByUserName(string userName);

        Task<List<FollowListVM>> UsersFollowers(int id, int pageIndex);
        Task<List<FollowListVM>> UsersFollowings(int id, int pageIndex);
    }
}
