using System.Collections.Generic;
using WorldCup.Domain.Service.Player.Dto;

namespace WorldCup.Domain.Service.Player
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDto> GetNames(string name);
        IEnumerable<PlayerDto> GetNamesByTeam(int idTeam);
    }
}
