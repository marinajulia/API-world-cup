using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Team
{
    public class TeamRepository : GenericRepository<TeamEntity>, ITeamRepository
    {
        public TeamRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
