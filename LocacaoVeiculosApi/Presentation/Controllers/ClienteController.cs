using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LocacaoVeiculosApi.Extensions;


namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly EntityService<Usuario> _usuarioService;
        private readonly IMapper _mapper;

        public ClienteController(EntityService<Usuario> usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/cliente")]
        [Authorize(Roles = "Cliente, Operador")]
        public async Task<IEnumerable<UsuarioCompleto>> Index()
        {
            var operadores = await _usuarioService.ListAsync();
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioCompleto>>(operadores);
        }

        [HttpGet("{id}")]
        [Route("/cliente/{id}")]
        [Authorize(Roles = "Cliente, Operador")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usuarioService.GetAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Usuario, UsuarioCompleto>((Usuario)result.Entity));
        }

        [HttpPost]
        [Route("/users")]
        [Route("/cliente")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create([FromBody] ClienteSalvar resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var cliente = _mapper.Map<ClienteSalvar, Usuario>(resource);
            var result = await _usuarioService.CreateAsync(cliente);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }

        [HttpPut]
        [Route("/cliente/{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteSalvar resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var cliente = _mapper.Map<ClienteSalvar, Usuario>(resource);
            var result = await _usuarioService.UpdateAsync(id, cliente);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }

        [HttpDelete]
        [Route("/cliente/{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Delete(int id)
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