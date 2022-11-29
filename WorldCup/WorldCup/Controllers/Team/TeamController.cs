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

        public TeamController(ILogger<TeamController> logger, IUnitOfWork uow, INotification notification)
        {
            _logger = logger;
            _uow = uow;
            _notification = notification;
        }

        [HttpGet("findbyid{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var team = await _uow.TeamRepository.GetByIdAsync(id);

            if (team == null)
                return Ok(_notification.GetNotifications());

            return Ok(team);
        }
       
    }
}
