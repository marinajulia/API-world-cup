using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Team.Dto;
using WorldCup.Domain.Service.User.Dto;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Enuns.UserMessages;
using WorldCup.SharedKernel.Enuns.UserStatus;
using WorldCup.SharedKernel.Helper;
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
        public async Task<bool> Block(UserDto userDto)
        {
            var user = await _uow.UserRepository.GetByIdAsync(userDto.Id);
            if (user == null)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.userNotFound.GetDescription());

            if (user.Status == UserStatus.BLOCK)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.userAlreadyBlocked.GetDescription());

            _userRepository.UpdateStatus(user.Id, UserStatus.BLOCK);

            _notification.AddWithReturn<bool>(UserMessagesEnum.successfullyBlockedUser.GetDescription());

            return true;
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

        public async Task<bool> Unlock(UserDto userDto)
        {
            var user = await _uow.UserRepository.GetByIdAsync(userDto.Id);
            if (user == null)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.userNotFound.GetDescription());

            if (user.Status == UserStatus.UNBLOCK)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.userAlreadyUnblocked.GetDescription());

            _userRepository.UpdateStatus(user.Id, UserStatus.UNBLOCK);

            _notification.AddWithReturn<bool>(UserMessagesEnum.successfullyBlockedUser.GetDescription());

            return true;
        }
    }
}
