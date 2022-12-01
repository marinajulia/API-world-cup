using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Player;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Api.Controllers.Player
{
    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IUnitOfWork _uow;
        private readonly INotification _notification;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<PlayerController> logger, IUnitOfWork uow, INotification notification, IPlayerService playerService)
        {
            _logger = logger;
            _uow = uow;
            _notification = notification;
            _playerService = playerService;
        }

        [HttpGet("findbyid{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var player = await _uow.PlayerRepository.GetByIdAsync(id);

            if (player == null)
                return Ok(_notification.GetNotifications());

            return Ok(player);
        }

        [HttpGet("findbyname/{name}")]
        public IActionResult GetByName(string name)
        {
            var players = _playerService.GetNames(name);

            if (players == null)
                return Ok(_notification.GetNotifications());

            return Ok(players);
        }

        [HttpGet("findbyidteam/{id}")]
        public async Task<IActionResult> GetByIdTeam(int id)
        {
            var players = await _playerService.GetNamesByTeam(id);

            if (players == null)
                return Ok(_notification.GetNotifications());

            return Ok(players);
        }

    }
}
