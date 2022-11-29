using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Player.Dto;

namespace WorldCup.Domain.Service.Player
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDto> GetNames(string name);
        Task<IEnumerable<PlayerDto>> GetNamesByTeam(int idTeam);
    }
}
