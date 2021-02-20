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
    public class VeiculosController : Controller
    {
        private readonly EntityService<Veiculo> _veiculoService;
        private readonly VeiculoService _vService;
        private readonly IMapper _mapper;

        public VeiculosController(EntityService<Veiculo> veiculoService, VeiculoService vService, IMapper mapper)
        {
            _veiculoService = veiculoService;
            _vService = vService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IEnumerable<VeiculoDto>> GetAllAsync()
        {
            var veiculos = await _veiculoService.ListAsync(v=>v.Marca, v=>v.Modelo, v=>v.Categoria);
            return _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoDto>>(veiculos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _veiculoService.GetAsync(x=> x.Id == id, v=>v.Marca, v=>v.Modelo, v=>v.Categoria);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return Ok(_mapper.Map<Veiculo, VeiculoDto>((Veiculo)result.Entity));
        }
        
        [HttpPost]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateVeiculoDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var veiculo = _mapper.Map<CreateVeiculoDto, Veiculo>(resource);
            var result = await _veiculoService.CreateAsync(veiculo);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateVeiculoDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        
            var veiculo = _mapper.Map<CreateVeiculoDto, Veiculo>(resource);
            var result = await _veiculoService.UpdateAsync(id, veiculo);
            
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
            var result = await _veiculoService.DeleteAsync(id);
        
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
        
            return StatusCode(204);
        }
        
        [HttpGet]
        [Route(("Disponiveis"))]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IEnumerable<VeiculoOutputRepository>> GetAllDisponivelAsync()
        {
            var veiculos = await _vService.GetVeiculosDisponiveisAsync();
            return _mapper.Map<IEnumerable<VeiculoOutputRepository>, IEnumerable<VeiculoOutputRepository>>(veiculos);

        }
    }
}