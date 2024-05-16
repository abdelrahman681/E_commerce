using E_commerce.API.Errors;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost(template: "Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _userServices.LogInAysnc(login);

            return user is not null ? Ok(user) : Unauthorized(new API_Response(401, "The Email or Paasword Is not Corect")); 
        }

        [HttpPost(template:"Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {


            return Ok(await _userServices.RegisterAysnc(register));
        }
    }
}
