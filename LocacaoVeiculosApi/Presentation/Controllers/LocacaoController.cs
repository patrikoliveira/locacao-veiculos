using System.Threading.Tasks;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LocacaoController : Controller
    {
        private readonly LocacaoService _locacaoService;

        public LocacaoController(LocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Simulacao([FromQuery] CalcularLocacaoInput calcularLocacaoInput)
        {
            
            var result = await _locacaoService.Simular(calcularLocacaoInput);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return Ok(result.Entity);
        }
    }
}