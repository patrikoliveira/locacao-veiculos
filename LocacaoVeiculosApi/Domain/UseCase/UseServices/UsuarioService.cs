using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Authentication;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using LocacaoVeiculosApi.Domain.ViewModel;
using LocacaoVeiculosApi.Infra.Database;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public class UsuarioService
    {
        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public UsuarioService(UsuarioRepository userRepository){  }
        private const int OPERADOR = 2;
        private IUsuarioRepository repository;

        public async Task<UsuarioJwt> Login(Usuario user, IToken token)
        {
            var loggedUser = await repository.FindByLoginAndPassword(user.CpfMatricula, user.Senha);
            if (loggedUser == null) throw new UsuarioNotFound("Usuário e senha inválidos.");
            return new UsuarioJwt()
            {
                id = loggedUser.Id,
                login = loggedUser.CpfMatricula,
                userType = loggedUser.TipoUsuario.ToString(),
                Token = token.GerarToken(loggedUser)
            };
        }

        public async Task<Usuario> All()
        {
            throw new NotImplementedException();
        }

        public async Task Save(Usuario user)
        {
          /*var size = await repository.CountByIdAndUser(user.Id, user.CpfMatricula);
            if (user.TipoUsuario == 1)
            {
                if (user.Endereco.ToString().IsNotNullOrEmpty<Usuario>)
                {
                  if(size > 0) throw new UsuarioUnico("CPF já cadastrado.");
                    await repository.Save(user);
                }
            }
            else if (user.TipoUsuario == 2)
            {
              if(size > 0) throw new UsuarioUnico("Matrícula já cadastrada.");
                await repository.Save(user);
            }
            else if (user.TipoUsuario == null)
            {
                user.TipoUsuario = OPERADOR;
                await repository.Save(user);
            }*/
        }
    }
}