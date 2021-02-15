using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using System;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Authentication;

namespace LocacaoVeiculosApi.Services
{
    public class UsuarioService
    {
        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        private const int OPERADOR = 2;
        private IUsuarioRepository repository;

        public async Task<UsuarioJwt> Login(Usuario user, IToken token)
        {
            IUsuario usuarioLogado;
            if (user.CpfMatricula.Length >= 11)
                usuarioLogado = await repository.FindByLoginAndPassword<Cliente>(user.CpfMatricula, user.Senha, Convert.ToInt16(TipoUsuario.Cliente));
            else usuarioLogado = await repository.FindByLoginAndPassword<Operador>(user.CpfMatricula, user.Senha, Convert.ToInt16(TipoUsuario.Operador));

            if (usuarioLogado == null) throw new UsuarioNotFound("Usuário não encontrado. Login ou senha inválidos.");
            return new UsuarioJwt()
            {
                id = usuarioLogado.Id,
                nome = usuarioLogado.Nome,
                login = usuarioLogado.CpfMatricula,
                tipoUsuario = usuarioLogado.TipoUsuario.ToString(),
                Token = token.GerarToken(usuarioLogado)
            };
        }

        public async Task<OperadorJwt> Login(OperatorLogin userLogin, IToken token)
        {
            IUsuario usuarioLogado = await repository.FindByLoginAndPassword<Operador>(userLogin.CpfMatricula, userLogin.Senha, Convert.ToInt16(TipoUsuario.Operador));
            if (usuarioLogado == null) throw new UsuarioNotFound("Usuário não encontrado. Login ou senha inválidos.");
            return new OperadorJwt()
            {
                id = usuarioLogado.Id,
                nome = usuarioLogado.Nome,
                Matricula = usuarioLogado.CpfMatricula,
                tipoUsuario = usuarioLogado.TipoUsuario.ToString(),
                Token = token.GerarToken(usuarioLogado)
            };
        }

        public Task<Usuario> RetornaTodosUsuarios()
        {
            return repository.All();
        }

        public async Task Save(Usuario user)
        {
            if (user.Id == 0)
            {
                if (user.Tipo == 0) user.TipoUsuario = Convert.ToInt16(user.Tipo);
                var size = await repository.CountByCpfMatricula<Usuario>(user.CpfMatricula, user.Tipo);
                if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
                await repository.Save(user);
            }
            else
            {
                var size = await repository.CountByIdAndCpfMatricula<Usuario>(user.Id, user.CpfMatricula, user.Tipo);
                if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
                await repository.Update(user);
            }
        }

        public async Task Delete(int id)
        {
            if (id == 0) throw new UsuarioIdVazio("Id não pode ser vazio");
            var user = await repository.FindById(id);
            if (user == null) throw new UsuarioNotFound("Usuário não encontrado");
            await repository.Delete(user);
        }

    }
}