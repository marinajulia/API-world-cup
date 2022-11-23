using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Team;

namespace WorldCup.Domain.Service.Player
{
    public class PlayerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTeam { get; set; }
        public TeamEntity Team { get; set; }
    }
}
