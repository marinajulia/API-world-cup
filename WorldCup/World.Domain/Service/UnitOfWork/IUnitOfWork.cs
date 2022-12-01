using System;
using WorldCup.Domain.Service.User;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;

namespace WorldCup.Infra.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IPlayerRepository PlayerRepository { get; }
        ITeamRepository TeamRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
