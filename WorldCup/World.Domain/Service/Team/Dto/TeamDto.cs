using System.Collections.Generic;
using WorldCup.Domain.Service.Player.Entity;

namespace WorldCup.Domain.Service.Team.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerEntity> Players { get; set; }
    }
}
