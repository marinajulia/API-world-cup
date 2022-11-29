using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Service.Team.Entity;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Base;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Infra.Repositories.Team
{
    public class TeamRepository : GenericRepository<TeamEntity>, ITeamRepository
    {
        private readonly ApplicationContext _context;

        public TeamRepository(ApplicationContext context, INotification iNotification) : base(context, iNotification)
        {
            _context = context;
        }

        public IEnumerable<TeamEntity> GetAll()
        {
            return _context.Teams;
        }

        public TeamEntity GetName(string name)
        {
            return _context.Teams
                .Include(x => x.Players)
                .FirstOrDefault(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public IEnumerable<TeamEntity> GetNames(string name)
        {
            return _context.Teams.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).Include(x => x.Players);
        }
    }
}
