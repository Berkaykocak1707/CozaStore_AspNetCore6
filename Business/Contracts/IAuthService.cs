using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get;}
        IEnumerable<CustomUser> GetAllUsers();
        Task<CustomUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task Update(UserDtoForUpdate userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto model);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}