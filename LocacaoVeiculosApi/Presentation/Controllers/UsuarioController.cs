using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using LocacaoVeiculosApi.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using LocacaoVeiculosApi.Domain.Services;
using AutoMapper;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService<Usuario> _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService<Usuario> usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/usuarios")]
        [Authorize(Roles = "Operador")]
        public async Task<ICollection<Usuario>> Index()
        {
            return await _usuarioService.ListAsync();
        }
    }
}