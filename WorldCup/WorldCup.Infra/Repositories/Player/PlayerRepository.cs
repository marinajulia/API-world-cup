using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Service.Player.Entity;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Infra.Repositories.Player
{
    public class PlayerRepository : GenericRepository<PlayerEntity>, IPlayerRepository
    {
        private readonly ApplicationContext _context;

        public PlayerRepository(ApplicationContext context, INotification iNotification) : base(context, iNotification)
        {
            _context = context;
        }

        public IEnumerable<PlayerEntity> GetNames(string name)
        {
            return _context.Players.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
        }

        public IEnumerable<PlayerEntity> GetNamesByTeam(int idTeam)
        {
            return _context.Players.Where(x => x.TeamId == idTeam);
        }
    }
}
