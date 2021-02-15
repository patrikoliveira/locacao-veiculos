using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Exceptions;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]    
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _usuarioService = new UsuarioService(new UsuarioRepository(), new EntityRepository());
        }

        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UsuarioLogin userLogin)
        {  
            try{
                return StatusCode(200, await _usuarioService.Login(userLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPost]
        [Route("/cliente/login")]
        [AllowAnonymous]
        public async Task<ActionResult> ClienteLogin(ClienteLogin clienteLogin)
        {  
            try{
                return StatusCode(200, await _usuarioService.Login(clienteLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPost]
        [Route("/operador/login")]
        [AllowAnonymous]
        public async Task<ActionResult> OperadorLogin(OperadorLogin operadorLogin)
        {  
            try{
                return StatusCode(200, await _usuarioService.Login(operadorLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }
        
    }
}