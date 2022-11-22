using ApiWorldCup.Domain;
using EFCore.ApiWorldCup.Data.Repositories.Base;

namespace ApiWorldCup.Data.Repositories.Player
{
    public interface IPlayerRepository : IGenericRepository<PlayerEntity>
    {
        //Task<Departamento> GetByIdAsync(int id);

        //void Add(Departamento departamento);
        //bool Save();
    }
}
