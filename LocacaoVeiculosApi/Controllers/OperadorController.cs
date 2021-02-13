using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Controllers
{
    public class OperadorController : ControllerBase
    {
        private readonly OperadorService _userService;

        [HttpPost]
        [Route("/usuario")]
        [AllowAnonymous]
            public async Task<ActionResult> Create(Usuario user){  
                try{
                await _operadorService.Save(user);
                return StatusCode(201);
                }
            catch(UsuarioUnico err){
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
            }
    }
}