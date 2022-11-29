using System.Collections.Generic;
using WorldCup.Domain.Service.Team.Dto;

namespace WorldCup.Domain.Service.Team
{
    public interface ITeamService
    {
        IEnumerable<TeamDto> GetNames(string name);
        IEnumerable<TeamDto> GetAll();
        TeamDto GetName(string name);
    }
}
