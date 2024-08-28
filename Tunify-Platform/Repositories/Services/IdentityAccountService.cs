using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private JwtTokenService jwtTokenService;

        public IdentityAccountService(UserManager<ApplicationUser> Manager, JwtTokenService jwtTokenService)
        {
            _userManager = Manager;
            this.jwtTokenService = jwtTokenService;

        }
        public async Task<UserDto> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7))

                };
            }

            return null;
        }

        public async Task Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<UserDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,

            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                // add roles to the new rigstred user
                await _userManager.AddToRolesAsync(user, registerdUserDto.Roles);
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user),
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7)) 

                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }


            return null;         
        }

       
        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(30)) // just for development purposes
            };
        }
    }
}
