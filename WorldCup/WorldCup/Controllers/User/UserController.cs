using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WorldCup.Api.Controllers.Team;
using WorldCup.Domain.Common.Token;
using WorldCup.Domain.Service.User;
using WorldCup.Domain.Service.User.Entity;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Api.Controllers.User
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IUnitOfWork _uow;
        private readonly INotification _notification;
        private readonly IUserService _userService;

        public UserController(ILogger<TeamController> logger, IUnitOfWork uow, INotification notification,
            IUserService userService)
        {
            _logger = logger;
            _uow = uow;
            _notification = notification;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string name, string password)
        {
            var user = _userService.Login(name, password);
            if (user == null)
                return BadRequest(_notification.GetNotifications());

            var token = TokenService.GenerateToken(user);
             
            return Ok(token);
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public IActionResult UserRegistration(string name, string password, string email)
        {
            var response = _userService.UserRegistration(name, password, email);
            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

        [HttpPost("block")]
        //[Authorize]
        public async Task<IActionResult> Block(int idUser)
        {
            var response = await _userService.Block(idUser);
            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

    }
}
