using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IAccount
    {
        // Add register
        public Task<UserDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState);

        // Add login 
        public Task<UserDto> Login(string username, string password);

        // Add logout 
        public Task Logout();

        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);
    }
}
