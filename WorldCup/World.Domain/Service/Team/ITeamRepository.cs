using System.Collections.Generic;
using WorldCup.Domain.Service.Player.Entity;
using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Team
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        IEnumerable<TeamEntity> GetNames(string name);
        PlayerEntity GetName(string name);
    }
}
