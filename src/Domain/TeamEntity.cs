using System.Collections.Generic;

namespace ApiWorldCup.Domain
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerEntity> Players { get; set; }

    }
}
