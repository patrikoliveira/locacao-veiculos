using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            _usuarioService = new UsuarioService(new UsuarioRepository(), new EntityRepository());
        }

        [HttpGet]
        [Route("/cliente")]
        [Authorize(Roles = "Cliente, Operador")]
        public async Task<ICollection<Cliente>> Index()
        {
            return await _usuarioService.RetornaTodosUsuarioPorTipo<Cliente>(TipoUsuario.Cliente);
        }

        [HttpPost]
        [Route("/users")]
        [Route("/cliente")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create([FromBody] ClienteSalvar cliente)
        {
            var cli = EntityBuilder.Call<Cliente>(cliente);
            try
            {
                await _usuarioService.Save(cli);
                return StatusCode(201);
            }
            catch (CpfInvalidoException err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
            catch (UsuarioUnico err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/cliente/{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteSalvar cliente)
        {
            var cli = EntityBuilder.Call<Cliente>(cliente);
            cli.Id = id;
            try
            {
                await _usuarioService.Save(cli);
                return StatusCode(204);
            }
            catch (CpfInvalidoException err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
            catch (UsuarioUnico err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpDelete]
        [Route("/cliente/{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.Delete(id);
                return StatusCode(204);
            }
            catch (UsuarioIdVazio err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(404, new
                {
                    Message = err.Message
                });
            }
        }
        
    }
}