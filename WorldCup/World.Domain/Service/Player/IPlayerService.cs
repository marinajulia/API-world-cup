using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Player.Dto;

namespace WorldCup.Domain.Service.Player
{
    public interface IPlayerService
    {
        IEnumerable<PlayerTeamDto> GetNames(string name);
        Task<IEnumerable<PlayerTeamDto>> GetNamesByTeam(int idTeam);
    }
}
