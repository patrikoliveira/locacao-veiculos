using Microsoft.AspNetCore.Mvc;
using locacao_veiculos_api.Domain.UseCase.UseServices;
using Microsoft.Extensions.Logging;
using locacao_veiculos_api.Infra.Database;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using locacao_veiculos_api.Domain.ViewModel;
using locacao_veiculos_api.Infra.Authentication;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly UserService _userService;
            private readonly ILogger<HomeController> _logger;

            [HttpPost]
            [Route("/users/login")]
            [AllowAnonymous]
            public async Task<ActionResult> Login(UserLogin userLogin){  
                try{
                    return StatusCode(200, await _userService.Login(new User(){
                        login = userLogin.login,
                        password = userLogin.password,
                    }, new Token()));
                }
                catch(UserNotFound err){
                    return StatusCode(401, new {
                        Message = err.Message
                    });
                }
            }



    
     }
}