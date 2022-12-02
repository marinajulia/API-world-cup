using System.Collections.Generic;
using WorldCup.Domain.Service.User.Dto;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Enuns.UserStatus;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Domain.Service.User
{
    public class UserService : IUserService
    {
        private readonly INotification _notification;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public UserService(INotification notification, IUserRepository userRepository,
            IUnitOfWork uow)
        {
            _notification = notification;
            _userRepository = userRepository;
            _uow = uow;
        }
        public bool Block(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserDto> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public UserDto GetUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool Post(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public bool PutChangePassword(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public bool PutChangeUser(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public bool Unlock(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStatus(int idUser, UserStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}
