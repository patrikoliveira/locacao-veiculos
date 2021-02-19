using System.Linq;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services.Communication;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Domain.Authentication;

namespace LocacaoVeiculosApi.Services
{
    public class LoginService
    {
        private readonly EntityRepository<Usuario> _usuarioRepository;

        public LoginService(EntityRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<EntityResponse> Logar(UsuarioLogin usuarioLogin, IToken token)
        {
            var usuarios = await _usuarioRepository.Filter(x => x.CpfMatricula == usuarioLogin.CpfMatricula);

            if (usuarios == null || usuarios.Count() == 0)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            var usuario = usuarios.First();
            if (usuario.Senha != usuarioLogin.Senha)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            return new EntityResponse((IEntity) new UsuarioJwt()
            {
                id = usuario.Id,
                nome = usuario.Nome,
                login = usuario.CpfMatricula,
                tipoUsuario = usuario.TipoUsuario.ToString(),
                Token = token.GerarToken(usuario)
            });
        }

        public async Task<EntityResponse> LogarCliente(ClienteLogin usuarioLogin, IToken token)
        {
            var usuarios = await _usuarioRepository.Filter(x => x.CpfMatricula == usuarioLogin.Cpf);

            if (usuarios == null || usuarios.Count() == 0)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            var usuario = usuarios.First();
            if (usuario.Senha != usuarioLogin.Senha)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            return new EntityResponse((IEntity) new UsuarioJwt()
            {
                id = usuario.Id,
                nome = usuario.Nome,
                login = usuario.CpfMatricula,
                tipoUsuario = usuario.TipoUsuario.ToString(),
                Token = token.GerarToken(usuario)
            });
        }

         public async Task<EntityResponse> LogarOperador(OperadorLogin usuarioLogin, IToken token)
        {
            var usuarios = await _usuarioRepository.Filter(x => x.CpfMatricula == usuarioLogin.Matricula);

            if (usuarios == null || usuarios.Count() == 0)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            var usuario = usuarios.First();
            if (usuario.Senha != usuarioLogin.Senha)
            {
                return new EntityResponse("Usuário/Senha Inválido");
            }

            return new EntityResponse((IEntity) new UsuarioJwt()
            {
                id = usuario.Id,
                nome = usuario.Nome,
                login = usuario.CpfMatricula,
                tipoUsuario = usuario.TipoUsuario.ToString(),
                Token = token.GerarToken(usuario)
            });
        }
    }
}