using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Extensions;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MarcaController : Controller
    {
        private readonly EntityService<Marca> _marcaService;
        private readonly IMapper _mapper;

        public MarcaController(EntityService<Marca> marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<MarcaDto>> GetAllAsync()
        {
            var marcas = await _marcaService.ListAsync();
            return _mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaDto>>(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _marcaService.GetAsync(x=> x.Id == id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return Ok(_mapper.Map<Marca, MarcaDto>((Marca)result.Entity));
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateMarcaDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var marca = _mapper.Map<CreateMarcaDto, Marca>(resource);
            var result = await _marcaService.CreateAsync(marca);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateMarcaDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var marca = _mapper.Map<CreateMarcaDto, Marca>(resource);
            var result = await _marcaService.UpdateAsync(id, marca);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _marcaService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
    }
}