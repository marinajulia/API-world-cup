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

        //a parte comentada (referente ao from services), é uma maneira para ser usada para recuperar o repositório sem a necessidade da injeção de dependencia
        //departamento/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id /*, [FromServices]IDepartemantoRepository repository*/)
        {
            //var departamento = await _departamentoRepository.GetByIdAsync(id);
            var departamento = await _uow.PlayerRepository.GetByIdAsync(id);

            return Ok(departamento);
        }
        //[HttpPost]
        //public IActionResult CreateDepartamento(Departamento departamento)
        //{
        //    //_departamentoRepository.Add(departamento);
        //    _uow.DepartamentoRepository.Add(departamento);

        //    //var saved = _departamentoRepository.Save();

        //    _uow.Commit();
        //    return Ok(departamento);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> RemoveDepartamentoAsync(int id)
        //{
        //    var departamento = await _uow.DepartamentoRepository.GetByIdAsync(id);

        //    _uow.DepartamentoRepository.Remove(departamento);
        //    _uow.Commit();
        //    return Ok(departamento);
        //}

        ////departamento/?descricao=teste
        //[HttpGet]
        //public async Task<IActionResult> ConsultarDepartamentoAsync([FromQuery] string descricao)
        //{
        //    var departamentos = await _uow.DepartamentoRepository.GetDataAsync(
        //        p => p.Descricao.Contains(descricao),
        //        p => p.Include(c => c.Colaboradores),
        //        take: 2); //take para retornar apenas 2 registros


        //    return Ok(departamentos);
        //}
    }
}
