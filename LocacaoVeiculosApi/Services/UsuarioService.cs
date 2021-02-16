using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using System;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Authentication;
using System.Collections.Generic;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services;

namespace LocacaoVeiculosApi.Services
{
    public class UsuarioService<Usuario> : IUsuarioService<T> where Usuario : class
    {
        private readonly IUsuarioRepository<Usuario> _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioService<Usuario> usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UsuarioJwt> Login(Usuario user, IToken token)
        {
            IUsuario usuarioLogado;
            if (user.CpfMatricula.Length >= 11)
                usuarioLogado = await _usuarioRepository.FindByLoginAndPassword<Cliente>(user.CpfMatricula, user.Senha, Convert.ToInt16(TipoUsuario.Cliente));
            else usuarioLogado = await _usuarioRepository.FindByLoginAndPassword<Operador>(user.CpfMatricula, user.Senha, Convert.ToInt16(TipoUsuario.Operador));

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
            IUsuario usuarioLogado = await _usuarioRepository.FindByLoginAndPassword<Operador>(userLogin.Matricula, userLogin.Senha, Convert.ToInt16(TipoUsuario.Operador));
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
            IUsuario usuarioLogado = await _usuarioRepository.FindByLoginAndPassword<Cliente>(userLogin.Cpf, userLogin.Senha, Convert.ToInt16(TipoUsuario.Cliente));
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
            return await _usuarioRepository.AllByType<T>(Convert.ToInt16(tipo));
        }

        public async Task<Usuario> RetornaTodosUsuarios()
        {
            var todosUsuarios = await _usuarioRepository.All<UsuarioCompleto>();
            var usuario = new List<Usuario>();
            foreach(var usuarioCompleto in todosUsuarios)
            {
                var user = EntityBuilder.Call<Usuario>(usuarioCompleto);
                //user.EndrecoId = EntityBuilder.Call<Endereco>(usuarioCompleto);
                usuario.Add(user);
            }
            return usuario;
        }

        public async Task Save(Usuario user)
        {
            if (user.Id == 0)
            {
                if (user.Tipo == 0) user.TipoUsuario = Convert.ToInt16(user.Tipo);
                var size = await _usuarioRepository.CountByCpfMatricula<Usuario>(user.CpfMatricula, user.Tipo);
                if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
                await _usuarioRepository.Save(user);
            }
            else
            {
                var size = await _usuarioRepository.CountByIdAndCpfMatricula<Usuario>(user.Id, user.CpfMatricula, user.Tipo);
                if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
                await _usuarioRepository.Update(user);
            }
        }

        public async Task<UsuarioResponse> DeleteAsync(int id)
        {
            var usuarioExistente = await _usuarioRepository.FindByIdAsync(id);

             if (usuarioExistente == null)
                return new UsuarioResponse("Usuário não encontrado.");
            try
            {
                _usuarioRepository.Remove(usuarioExistente);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(usuarioExistente);
            }
            catch (UsuarioNotFound e)
            {
                return new UsuarioResponse($"Um erro ocorreu ao deletar a categoria: {e.Message}");
            }
        }
    }
}