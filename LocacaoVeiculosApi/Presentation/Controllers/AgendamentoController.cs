using System.Threading.Tasks;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AgendamentoController : Controller
    {
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        [Route("Simular")]
        public async Task<IActionResult> Simular([FromQuery] CalcularLocacaoInput calcularLocacaoInput)
        {
            var result = await _agendamentoService.Simular(calcularLocacaoInput);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            // return Ok(result.Entity);
            return StatusCode(200, result.Entity);
        }

        [HttpPost]
        [Route("Agendar")]
        public async Task<IActionResult> Alugar([FromBody] CalcularLocacaoInput input)
        {
            var result = await _agendamentoService.Alugar(input);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return StatusCode(201, result.Entity);
        }

        [HttpPost]
        [Route(("Devolver"))]
        public async Task<IActionResult> Devolver([FromBody] DevolucaoInput input)
        {
            var result = await _agendamentoService.Devolver(input);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return StatusCode(201, result.Entity);
        }
    }
}