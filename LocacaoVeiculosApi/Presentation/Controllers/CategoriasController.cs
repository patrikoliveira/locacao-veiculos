using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using LocacaoVeiculosApi.Extensions;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriasController: Controller
    {
        private readonly EntityService<Categoria> _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(EntityService<Categoria> categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var categorias = await _categoriaService.ListAsync();
            return _mapper.Map<IEnumerable<IEntity>, IEnumerable<CategoriaDto>>(categorias);
        }
        
        [HttpGet("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoriaService.GetAsync(x=> x.Id == id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Categoria, CategoriaDto>((Categoria) result.Entity));

        }
        
        [HttpPost]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategoriaDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var categoria = _mapper.Map<CreateCategoriaDto, Categoria>(resource);
            var result = await _categoriaService.CreateAsync(categoria);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        //[Authorize(Roles = "Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateCategoriaDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var categoria = _mapper.Map<CreateCategoriaDto, Categoria>(resource);
            var result = await _categoriaService.UpdateAsync(id, categoria);
            
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
            var result = await _categoriaService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(204);
        }
        
    }
}