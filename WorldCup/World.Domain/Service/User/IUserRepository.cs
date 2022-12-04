using System.Collections.Generic;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Repositories.Base;
using WorldCup.SharedKernel.Enuns.UserStatus;

namespace WorldCup.Domain.Service.User
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity Post(UserEntity user);
        UserEntity GetByName(string name);
        IEnumerable<UserEntity> GetNames(string name);
        UserEntity PutChangePassword(UserEntity user);
        UserEntity PutChangeUser(UserEntity user);
        UserEntity GetUser(string username, string password);
        void UpdateStatus(int idUser, UserStatus status);
    }
}
