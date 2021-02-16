using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VeiculosController : Controller
    {
        private readonly IVeiculoService<Veiculo> _veiculoService;

        public VeiculosController(IVeiculoService<Veiculo> veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IEnumerable<IEntity>> ObterTodosAsync()
        {
            return await _veiculoService.ListAsync();
        }
    }
}