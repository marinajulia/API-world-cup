using System.Collections.Generic;
using WorldCup.Domain.Service.User.Dto;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.SharedKernel.Enuns.UserStatus;

namespace WorldCup.Domain.Service.User
{
    public interface IUserService
    {
        bool Post(UserEntity user);
        IEnumerable<UserDto> GetByName(string name);
        bool PutChangePassword(UserEntity user);
        bool PutChangeUser(UserEntity user);
        UserDto GetUser(string username, string password);
        void UpdateStatus(int idUser, UserStatus status);
        bool Block(UserDto user);
        bool Unlock(UserDto user);
    }
}
