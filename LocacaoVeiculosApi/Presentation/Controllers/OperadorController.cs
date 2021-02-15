using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    public class OperadorController
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<OperadorController> _logger;
        
        public OperadorController(ILogger<OperadorController> logger)
        {
            _logger = logger;
            _usuarioService = new UsuarioService(new UsuarioRepository(), new EntityRepository());
        }
    }
}