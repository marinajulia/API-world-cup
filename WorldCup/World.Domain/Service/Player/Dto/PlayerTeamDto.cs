using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Domain.Service.Player.Dto
{
    public class PlayerTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTeam { get; set; }
        public string Team { get; set; }
    }
}
