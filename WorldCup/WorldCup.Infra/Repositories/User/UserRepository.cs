using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Common.Criptografia;
using WorldCup.Domain.Service.User;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;
using WorldCup.SharedKernel.Enuns.UserStatus;
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

        public UserEntity GetByName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public IEnumerable<UserEntity> GetNames(string name)
        {
            return _context.Users.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
        }

        public UserEntity GetUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Name == username &&
                x.Password == PasswordService.Encrypt(password));
            return user;
        }

        public UserEntity Post(UserEntity user)
        {
            user.Password = PasswordService.Encrypt(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public UserEntity PutChangePassword(UserEntity user)
        {
            user.Password = PasswordService.Encrypt(user.Password);
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public UserEntity PutChangeUser(UserEntity user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void UpdateStatus(int idUsuario, UserStatus status)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == idUsuario);

            user.Status = status;

            _context.SaveChanges();
        }

        public UserEntity GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
