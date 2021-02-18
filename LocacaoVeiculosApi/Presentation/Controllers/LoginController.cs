using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Presentation.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUsuarioService<Usuario> _usuarioService;
        private readonly IMapper _mapper;

        public LoginController(IUsuarioService<Usuario> usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/usuario/login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(Usuario userLogin)
        {  
            try
            {
                return StatusCode(200, await _usuarioService.Login(userLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPost]
        [Route("/cliente/login")]
        [AllowAnonymous]
        public async Task<ActionResult> ClienteLogin(ClienteLogin userLogin)
        {
            try
            {
                return StatusCode(200, await _usuarioService.Login(userLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
        }

        [HttpPost]
        [Route("/operador/login")]
        [AllowAnonymous]
        public async Task<ActionResult> OperadorLogin(OperadorLogin userLogin)
        {
            try
            {
                return StatusCode(200, await _usuarioService.Login(userLogin, new Token()));
            }
            catch (UsuarioNotFound err)
            {
                return StatusCode(401, new
                {
                    Message = err.Message
                });
            }
        }

    }
}