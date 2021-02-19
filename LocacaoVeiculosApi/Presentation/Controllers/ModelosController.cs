using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Extensions;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ModelosController : Controller
    {
        private readonly EntityService<Modelo> _modeloService;
        private readonly IMapper _mapper;
        
        public ModelosController(EntityService<Modelo> modeloService, IMapper mapper)
        {
            _modeloService = modeloService;
            _mapper = mapper;
        }
        
        [HttpGet]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IEnumerable<ModeloDto>> GetAllAsync()
        {
            var modelos = await _modeloService.ListAsync();
            return _mapper.Map<IEnumerable<Modelo>, IEnumerable<ModeloDto>>(modelos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _modeloService.GetAsync(x=> x.Id == id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return Ok(_mapper.Map<Modelo, ModeloDto>((Modelo)result.Entity));
        }
        
        [HttpPost]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateModeloDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var modelo = _mapper.Map<CreateModeloDto, Modelo>(resource);
            var result = await _modeloService.CreateAsync(modelo);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateModeloDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var modelo = _mapper.Map<CreateModeloDto, Modelo>(resource);
            var result = await _modeloService.UpdateAsync(id, modelo);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
        
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _modeloService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
    }
}