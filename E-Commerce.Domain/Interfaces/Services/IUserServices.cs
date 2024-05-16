using E_Commerce.Domain.DataTransfareObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<UserDto?> LogInAysnc(LoginDto login);
        public Task<UserDto?> RegisterAysnc(RegisterDto register);

    }
}
