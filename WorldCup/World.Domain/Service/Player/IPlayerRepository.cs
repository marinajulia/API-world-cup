using WorldCup.Domain.Service.Player.Entity;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Player
{
    public interface IPlayerRepository : IGenericRepository<PlayerEntity>
    {
    }
}
