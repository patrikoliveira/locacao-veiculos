using System;
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
    public class OperadorController
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<OperadorController> _logger;

        public OperadorController(ILogger<OperadorController> logger)
        {
            _logger = logger;
            _usuarioService = new UsuarioService(new UsuarioRepository(), new EntityRepository());
        }

        [HttpGet]
        [Route("/operador")]
        [Authorize(Roles = "Cliente, Operador")]
        public async Task<ICollection<Operador>> Index()
        {
            return await _usuarioService.RetornaTodosUsuarioPorTipo<Operador>(TipoUsuario.Operador);
        }

        [HttpPost]
        [Route("/operador")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create([FromBody] OperadorSalvar op)
        {
            var oper = EntityBuilder.Call<Operador>(op);
            try
            {
                await _usuarioService.Save(oper);
                return StatusCode(201);
            }
            catch (UsuarioUnico err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
        }

        private IActionResult StatusCode(int v)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/operador/{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Update(int id, [FromBody] OperadorSalvar op)
        {
            var oper = EntityBuilder.Call<Operador>(op);
            oper.Id = id;
            try
            {
                await _usuarioService.Save(oper);
                return StatusCode(204);
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
        [Route("/operador/{id}")]
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