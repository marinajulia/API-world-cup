using System.Collections.Generic;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Domain.Service.User
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity Post(UserEntity user);
        IEnumerable<UserEntity> GetByName(string nome);
        UserEntity PutChangePassword(UserEntity user);
        UserEntity PutChangeUser(UserEntity user);
        UserEntity GetUser(string username, string password);
        UserEntity GetByStatus(int id);
        void UpdateStatus(int idUsuario, int idStatus);
    }
}
