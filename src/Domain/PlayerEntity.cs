namespace ApiWorldCup.Domain
{
    public class PlayerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTeam { get; set; }
        public TeamEntity Team { get; set; }
    }
}
