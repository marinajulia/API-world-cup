using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Domain.Service.User;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;
using WorldCup.Infra.Repositories.Team;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Infra.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context, INotification iNotification) : base(context, iNotification)
        {
            _context = context;
        }

        public IEnumerable<UserEntity> GetByName(string nome)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity GetByStatus(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity GetUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity Post(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity PutChangePassword(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity PutChangeUser(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStatus(int idUsuario, int idStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}
