using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCup.Domain.Service.Team.Entity;

namespace WorldCup.Domain.Service.Player.Entity
{
    public class PlayerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Teams")]
        public int IdTeam { get; set; }
        public TeamEntity Team { get; set; }
    }
}
