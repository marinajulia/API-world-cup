using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCup.Domain.Service.User.Dto;
using WorldCup.Domain.Service.User.Entity;

namespace WorldCup.Domain.Service.User
{
    public interface IUserService
    {
        void Login(UserEntity user);
        IEnumerable<UserDto> GetByName(string name);
        Task<bool> ChangePassword(UserEntity user);
        Task<bool> Block(UserDto user);
        Task<bool> Unlock(UserDto user);
        bool UserRegistration(UserEntity user);
    }
}
