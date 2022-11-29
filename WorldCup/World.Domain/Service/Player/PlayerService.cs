using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorldCup.Domain.Service.Player.Dto;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Helper;
using WorldCup.SharedKernel.Notification;
using WorldCup.SharedKernel.UserMessages;

namespace WorldCup.Domain.Service.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly INotification _notification;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUnitOfWork _uow;

        public PlayerService(INotification notification, IPlayerRepository playerRepository, ITeamRepository teamRepository,
            IUnitOfWork uow)
        {
            _notification = notification;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _uow = uow;
        }
        public IEnumerable<PlayerTeamDto> GetNames(string name)
        {
            var players = _playerRepository.GetNames(name);
            
            if(players == null)
                return _notification.AddWithReturn<IEnumerable<PlayerTeamDto>>(UserMessagesEnum.notFound.GetDescription());

            return players.Select(x => new PlayerTeamDto
            {
                Id = x.Id,
                Name = x.Name,
                IdTeam = x.TeamId,
                Team = x.Team.Name
            }).ToList();
        }

        public async Task<IEnumerable<PlayerTeamDto>> GetNamesByTeam(int idTeam)
        {
            var team = await _uow.TeamRepository.GetByIdAsync(idTeam);

            if (team == null)
                return _notification.AddWithReturn<IEnumerable<PlayerTeamDto>>(UserMessagesEnum.teamNotFound.GetDescription());

            var players = _playerRepository.GetNamesByTeam(team.Id);

            if (players == null)
                return _notification.AddWithReturn<IEnumerable<PlayerTeamDto>>(UserMessagesEnum.playersNotFound.GetDescription());

            return players.Select(x => new PlayerTeamDto
            {
                Id = x.Id,
                Name = x.Name,
                IdTeam = x.TeamId,
                Team = x.Team.Name
            }).ToList();
        }
    }
}
