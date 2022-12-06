using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCup.Domain.Service.User.Dto;
using WorldCup.Domain.Service.User.Entity;

namespace WorldCup.Domain.Service.User
{
    public interface IUserService
    {
        UserEntity Login(string name, string password);
        IEnumerable<UserDto> GetByName(string name);
        Task<bool> ChangePassword(UserEntity user);
        Task<bool> Block(int idUser);
        Task<bool> Unlock(int idUser);
        bool UserRegistration(string name, string password, string email);
    }
}
