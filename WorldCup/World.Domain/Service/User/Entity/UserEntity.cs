using System.ComponentModel.DataAnnotations;
using WorldCup.SharedKernel.Enuns.UserStatus;

namespace WorldCup.Domain.Service.User.Entity
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public UserStatus Status { get; set; }
    }
}
