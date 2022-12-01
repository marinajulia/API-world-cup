using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Service.Team.Dto;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Enuns.UserMessages;
using WorldCup.SharedKernel.Helper;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Domain.Service.Team
{
    public class TeamService : ITeamService
    {
        private readonly INotification _notification;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUnitOfWork _uow;

        public TeamService(INotification notification, IPlayerRepository playerRepository, ITeamRepository teamRepository,
            IUnitOfWork uow)
        {
            _notification = notification;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _uow = uow;
        }
        public IEnumerable<TeamDto> GetAll()
        {
            var teams = _teamRepository.GetAll();

            if (teams == null)
                return _notification.AddWithReturn<IEnumerable<TeamDto>>(UserMessagesEnum.notFound.GetDescription());

            return teams.Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public TeamDto GetName(string name)
        {
            var teams = _teamRepository.GetName(name);

            if (teams == null)
                return _notification.AddWithReturn<TeamDto>(UserMessagesEnum.notFound.GetDescription());

            return new TeamDto
            {
                Id = teams.Id,
                Name = teams.Name,
                Players = teams.Players,
            };
        }

        public IEnumerable<TeamDto> GetNames(string name)
        {
            var teams = _teamRepository.GetNames(name);

            if (teams == null)
                return _notification.AddWithReturn<IEnumerable<TeamDto>>(UserMessagesEnum.notFound.GetDescription());

            return teams.Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                Players = x.Players,
            }).ToList();
        }
    }
}
