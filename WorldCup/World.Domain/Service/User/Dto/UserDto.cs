using WorldCup.SharedKernel.Enuns.UserStatus;

namespace WorldCup.Domain.Service.User.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}
