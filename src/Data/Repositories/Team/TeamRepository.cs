using ApiWorldCup.Domain;
using EFCore.ApiWorldCup.Data.Repositories.Base;
using src.Data;

namespace ApiWorldCup.Data.Repositories.Team
{
    public class TeamRepository : GenericRepository<TeamEntity>, ITeamRepository
    {
        //private readonly ApplicationContext _context;
        //private readonly DbSet<Departamento> _dbset;

        public TeamRepository(ApplicationContext context) : base(context)
        {
            //_context = context;
            //_dbset = _context.Set<Departamento>();
        }
        //esses dois métodos comentados abaixo não são mais necessários pois existem no repositório genérico
        //public void Add(Departamento departamento)
        //{
        //    _dbset.Add(departamento);
        //}

        //public async Task<Departamento> GetByIdAsync(int id)
        //{
        //    return await _dbset
        //        .Include(p => p.Colaboradores)
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //}

        //public bool Save()
        //{
        //    return _context.SaveChanges() > 0;
        //}
    }
}
