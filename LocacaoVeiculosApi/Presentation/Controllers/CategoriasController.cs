using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using LocacaoVeiculosApi.Extensions;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriasController: Controller
    {
        private readonly ICategoriaService<Categoria> _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaService<Categoria> categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var categorias = await _categoriaService.ListAsync();
            return _mapper.Map<IEnumerable<IEntity>, IEnumerable<CategoriaDto>>(categorias);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoriaService.GetAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Categoria, CategoriaDto>(result.Categoria));

        }
        
        [HttpPost]
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

            return Ok(_mapper.Map<Categoria, CategoriaDto>(result.Categoria));
        }
        
        [HttpPut("{id}")]
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

            return Ok(_mapper.Map<Categoria, CategoriaDto>(result.Categoria));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoriaService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<Categoria, CategoriaDto>(result.Categoria));
        }
        
    }
}