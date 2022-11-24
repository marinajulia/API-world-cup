using WorldCup.Domain.Service.Team.Entity;

namespace WorldCup.Domain.Service.Player.Dto
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTeam { get; set; }
        public TeamEntity Team { get; set; }
    }
}
