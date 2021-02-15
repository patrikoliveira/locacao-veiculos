using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using LocacaoVeiculosApi.Domain.Entities;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Services;
using System.Collections.Generic;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly EntityService _entityService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _entityService = new EntityService(new EntityRepository());
        }

        [HttpGet]
        [Route("/usuarios")]
        [Authorize(Roles = "Operador")]
        public async Task<ICollection<Usuario>> Index()
        {
            return await _entityService.All<Usuario>();
        }
    }
}