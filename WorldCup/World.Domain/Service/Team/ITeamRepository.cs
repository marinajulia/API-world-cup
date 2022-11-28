using System.Collections.Generic;
using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Team
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        IEnumerable<TeamEntity> GetNames(string name);
        IEnumerable<TeamEntity> GetAll();
        TeamEntity GetName(string name);
    }
}
