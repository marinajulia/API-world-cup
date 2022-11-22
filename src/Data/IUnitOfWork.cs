using ApiWorldCup.Data.Repositories.Player;
using ApiWorldCup.Data.Repositories.Team;
using EFCore.ApiWorldCup.Data.Repositories;
using System;

namespace EFCore.ApiWorldCup.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IPlayerRepository PlayerRepository { get; }
        ITeamRepository TeamRepository { get; }
    }
}
