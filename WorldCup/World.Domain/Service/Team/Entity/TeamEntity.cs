using System.Collections.Generic;
using WorldCup.Domain.Service.Player.Entity;

namespace WorldCup.Domain.Service.Team.Entity
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerEntity> Players { get; set; }
    }
}
