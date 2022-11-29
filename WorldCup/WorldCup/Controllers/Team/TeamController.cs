using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Numerics;
using System.Threading.Tasks;
using WorldCup.Domain.Service.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Api.Controllers.Team
{
    [ApiController]
    [Route("team")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IUnitOfWork _uow;
        private readonly INotification _notification;
        private readonly ITeamService _teamService;

        public TeamController(ILogger<TeamController> logger, IUnitOfWork uow, INotification notification,
            ITeamService teamService)
        {
            _logger = logger;
            _uow = uow;
            _notification = notification;
            _teamService = teamService;
        }

        [HttpGet("findbyid{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var team = await _uow.TeamRepository.GetByIdAsync(id);

            if (team == null)
                return Ok(_notification.GetNotifications());

            return Ok(team);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var teams = _teamService.GetAll();

            if (teams == null)
                return Ok(_notification.GetNotifications());

            return Ok(teams);
        }

        [HttpGet("fingbyname{name}")]
        public IActionResult GetByName(string name)
        {
            var team = _teamService.GetName(name);

            if (team == null)
                return Ok(_notification.GetNotifications());

            return Ok(team);
        }

        [HttpGet("getnames{name}")]
        public IActionResult GetNames(string name)
        {
            var teams = _teamService.GetNames(name);

            if (teams == null)
                return Ok(_notification.GetNotifications());

            return Ok(teams);
        }
    }
}
