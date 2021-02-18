using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LocacaoVeiculosApi.Extensions;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OperadorController : Controller
    {
        private readonly EntityService<Usuario> _usuarioService;
        private readonly IMapper _mapper;

        public OperadorController(EntityService<Usuario> usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        // [Route("/operador")]
        //[Authorize(Roles = "Cliente, Operador")]
        [AllowAnonymous]
        public async Task<IEnumerable<OperadorDto>> Index()
        {
            var operadores = await _usuarioService.ListAsync();
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<OperadorDto>>(operadores);
        }

        [HttpGet("{id}")]
        // [Route("/operador/{id}")]
        //[Authorize(Roles = "Cliente, Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _usuarioService.GetAsync(x=> x.Id == id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Usuario, OperadorDto>((Usuario)result.Entity));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperadorDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var operador = _mapper.Map<CreateOperadorDto, Operador>(resource);
            var usuario = new Usuario()
            {
                Nome = operador.Nome,
                Senha = operador.Senha,
                CpfMatricula = operador.Matricula,
                TipoUsuario = TipoUsuario.Operador
            };
            var result = await _usuarioService.CreateAsync(usuario);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateOperadorDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var operador = _mapper.Map<CreateOperadorDto, Operador>(resource);
            var usuario = new Usuario()
            {
                Nome = operador.Nome,
                Senha = operador.Senha,
                CpfMatricula = operador.Matricula,
                TipoUsuario = TipoUsuario.Operador
            };
            var result = await _usuarioService.UpdateAsync(id, usuario);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
        
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _usuarioService.DeleteAsync(id);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return StatusCode(204);
        }
    }
}