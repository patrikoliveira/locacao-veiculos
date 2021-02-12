using Microsoft.AspNetCore.Mvc;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.ViewModel;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            private readonly UsuarioService _userService;
            private readonly ILogger<HomeController> _logger;

            [HttpPost]
            [Route("/login")]
            [AllowAnonymous]
            public async Task<ActionResult> Login(UsuarioLogin userLogin){  
                try{
                    return StatusCode(200, await _userService.Login(new Usuario(){
                        Login = userLogin.login,
                        senha = userLogin.password,
                    }, new Token()));
                }
                catch(UserNotFound err){
                    return StatusCode(401, new {
                        Message = err.Message
                    });
                }
            }

        [HttpGet]
        [Route("/usuario")]
        public async Task<ICollection<UsuarioView>> Index()
        {
            return await _userService.All();
        }

     }
}