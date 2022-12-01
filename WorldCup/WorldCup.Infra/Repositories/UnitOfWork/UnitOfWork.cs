using WorldCup.Domain.Service.User;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.Infra.Repositories.User;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly INotification _notification;
        public UnitOfWork(ApplicationContext context, INotification notification)
        {
            _context = context;
            _notification = notification;
        }

        //private IDepartamentoRepository _departamentoRepository;

        //essa é uma estratégia muito usada para não precisar manter na memória objetos que não estão sendo utilizados no momento
        //o ponto negativo seria que teria que duplicar esse código para cada repositório
        //public IDepartamentoRepository DepartamentoRepository
        //{
        //    get => _departamentoRepository ?? (_departamentoRepository = new DepartamentoRepository(_context));
        //}

        private IPlayerRepository _playerRepository;

        private ITeamRepository _teamRepository;

        private IUserRepository _userRepository;

        public IPlayerRepository PlayerRepository
        {
            get => _playerRepository ?? (_playerRepository = new PlayerRepository(_context, _notification));
        }
        public ITeamRepository TeamRepository
        {
            get => _teamRepository ?? (_teamRepository = new TeamRepository(_context, _notification));
        }
        public IUserRepository UserRepository
        {
            get => _userRepository ?? (_userRepository = new UserRepository(_context, _notification));
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
