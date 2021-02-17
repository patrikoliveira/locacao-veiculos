using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
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
        //[AllowAnonymous]
        public async Task<IEnumerable<OperadorDto>> Index()
        {
            var operadores = await _usuarioService.ListAsync();
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<OperadorDto>>(operadores);
        }

        [HttpGet("{id}")]
        // [Route("/operador/{id}")]
        [Authorize(Roles = "Cliente, Operador")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _usuarioService.GetAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Usuario, OperadorDto>((Usuario)result.Entity));
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperadorDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var operador = _mapper.Map<CreateOperadorDto, Operador>(resource);
            var result = await _usuarioService.CreateAsync(operador);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OperadorSalvar resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var operador = _mapper.Map<OperadorSalvar, Usuario>(resource);
            var result = await _usuarioService.UpdateAsync(id, operador);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
        
        [HttpDelete("{id}")]
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