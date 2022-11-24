using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.UnitOfWork;

namespace WorldCup.Api.Controllers.Player
{
    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IUnitOfWork _uow;
        //private readonly IDepartamentoRepository _departamentoRepository;

        public PlayerController(ILogger<PlayerController> logger, IPlayerRepository playerRepository, IUnitOfWork uow)
        {
            _logger = logger;
            //_departamentoRepository = repository;
            _uow = uow;
        }

        [HttpGet("findbyid{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var departamento = await _uow.PlayerRepository.GetByIdAsync(id);

            return Ok(departamento);
        }

        [HttpGet("findbyname/{name}")]
        public async Task<IActionResult> GetByNameAsync(int name)
        {
            var departamento = await _uow.PlayerRepository.GetByIdAsync(name);

            return Ok(departamento);
        }

    }
}
