using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Player;

namespace WorldCup.Domain.Service.Team
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerEntity> Players { get; set; }
    }
}
