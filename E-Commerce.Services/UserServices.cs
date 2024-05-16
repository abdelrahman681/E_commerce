using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.Identity;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenServices _token;

        public UserServices(ITokenServices token, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _token = token;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserDto?> LogInAysnc(LoginDto login)
        {
            //dto=>check user has this email or not
            //if has check on password
            //create token
            //return dto 
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is not null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                if (result.Succeeded)
                    return new UserDto
                    {
                        Email = user.Email,
                        DisplayName = user.DisplayName,
                        Token = _token.GenerateToken(user)
                    };
            }
            return null;
        }

        public async Task<UserDto?> RegisterAysnc(RegisterDto register)
        {
            var user = await _userManager.FindByEmailAsync(register.Email);
            if (user is not null)
                throw new Exception("The Email is Exsist");
            var AppUser = new ApplicationUser
            {
                Email = register.Email,
                DisplayName = register.DisplayName,
                UserName = register.DisplayName,

            };
            var result = await _userManager.CreateAsync(AppUser, register.Password);
            if (!result.Succeeded)
                throw new Exception("Error");
            return new UserDto
            {
                DisplayName = AppUser.DisplayName,
                Email = AppUser.Email,
                Token = _token.GenerateToken(AppUser)
            };

        }
    }
}
