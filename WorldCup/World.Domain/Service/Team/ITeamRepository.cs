using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Team
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
    }
}
