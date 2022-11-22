using ApiWorldCup.Domain;
using EFCore.ApiWorldCup.Data.Repositories.Base;

namespace ApiWorldCup.Data.Repositories.Team
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        //Task<Departamento> GetByIdAsync(int id);

        //void Add(Departamento departamento);
        //bool Save();
    }
}
