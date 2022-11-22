namespace ApiWorldCup.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTeam { get; set; }
        public Team Team { get; set; }
    }
}
