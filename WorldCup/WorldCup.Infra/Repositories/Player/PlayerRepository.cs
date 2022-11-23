using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Player;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;

namespace WorldCup.Infra.Repositories.Player
{
    public class PlayerRepository : GenericRepository<PlayerEntity>, IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
