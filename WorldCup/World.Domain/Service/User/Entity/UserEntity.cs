using System.ComponentModel.DataAnnotations;
using WorldCup.SharedKernel.Enuns.UserPermissions;
using WorldCup.SharedKernel.Enuns.UserStatus;

namespace WorldCup.Domain.Service.User.Entity
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UserPermissions Permission { get; set; }
    }
}
