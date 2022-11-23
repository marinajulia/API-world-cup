using WorldCup.Domain.Service.Player;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Player
{
    public interface IPlayerRepository : IGenericRepository<PlayerEntity>
    {
    }
}
