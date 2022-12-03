using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var user = _userRepository.GetByName(name);

            if(user == null)
                _notification.AddWithReturn<bool>(UserMessagesEnum.userNotFound.GetDescription());

            return user.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).ToList(); ;
        }

        public void Login(UserEntity user)
        {
            if (string.IsNullOrEmpty(user.Name)|| string.IsNullOrEmpty(user.Password))
                _notification.AddWithReturn<bool>(UserMessagesEnum.emptyFields.GetDescription());

            var usuarioData = _userRepository.GetUser(user.Name, user.Password);
            if (usuarioData == null)
                _notification.AddWithReturn<bool>(UserMessagesEnum.incorrectUsernameOrPassword.GetDescription());

            _notification.AddWithReturn<bool>(UserMessagesEnum.userLoggedInSuccessfully.GetDescription());
        }

        public async Task<bool> ChangePassword(UserEntity userEntity)
        {
            if (string.IsNullOrEmpty(userEntity.Name))
                _notification.AddWithReturn<bool>(UserMessagesEnum.emptyFields.GetDescription());

            var user = await _uow.UserRepository.GetByIdAsync(userEntity.Id);
            if (user == null)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.userNotFound.GetDescription());

            user.Password = userEntity.Password;
            _userRepository.PutChangePassword(user);

            if(user == null)
                return _notification.AddWithReturn<bool>(UserMessagesEnum.UnableToChangePassword.GetDescription());

            return _notification.AddWithReturn<bool>(UserMessagesEnum.PasswordChangedSuccessfully.GetDescription());
        }

        public bool ChangeUser(UserEntity user)
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
