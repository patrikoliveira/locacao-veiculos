using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using System;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Authentication;
using System.Collections.Generic;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.Controllers;

namespace LocacaoVeiculosApi.Services
{
    public class UsuarioService
    {
        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public UsuarioService(UsuarioRepository usuarioRepository, EntityRepository entityRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.entityRepository = entityRepository;
        }

        private IUsuarioRepository repository;
        private UsuarioRepository usuarioRepository;
        private EntityRepository entityRepository;

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

        public async Task<OperadorJwt> Login(OperadorLogin userLogin, IToken token)
        {
            IUsuario usuarioLogado = await repository.FindByLoginAndPassword<Operador>(userLogin.Matricula, userLogin.Senha, Convert.ToInt16(TipoUsuario.Operador));
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
        public async Task<ClienteJwt> Login(ClienteLogin userLogin, IToken token)
        {
            IUsuario usuarioLogado = await repository.FindByLoginAndPassword<Cliente>(userLogin.Cpf, userLogin.Senha, Convert.ToInt16(TipoUsuario.Cliente));
            if (usuarioLogado == null) throw new UsuarioNotFound("Usuário não encontrado. Login ou senha inválidos.");
            return new ClienteJwt()
            {
                id = usuarioLogado.Id,
                nome = usuarioLogado.Nome,
                Cpf = usuarioLogado.CpfMatricula,
                tipoUsuario = usuarioLogado.TipoUsuario.ToString(),
                Token = token.GerarToken(usuarioLogado)
            };
        }

        public async Task<ICollection<T>> RetornaTodosUsuarioPorTipo<T>(TipoUsuario tipo){
            return await repository.AllByType<T>(Convert.ToInt16(tipo));
        }

        public async Task<Usuario> RetornaTodosUsuarios()
        {
           var todosUsuarios = await repository.AllByType<UsuarioCompleto>();
            var usuario = new List<Usuario>();
            foreach(var completeUser in todosUsuarios)
            {
                var user = EntityBuilder.Call<Usuario>(completeUser);
                user.EnderecoId = EntityBuilder.Call<Endereco>(completeUser);
                usuario.Add(user);
            }
            return usuario;
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
            await repository.Delete<IUsuario>(id);
        }

    }
}