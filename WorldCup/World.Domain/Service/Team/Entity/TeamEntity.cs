using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldCup.Domain.Service.Player.Entity;

namespace WorldCup.Domain.Service.Team.Entity
{
    public class TeamEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerEntity> Players { get; set; }
    }
}
