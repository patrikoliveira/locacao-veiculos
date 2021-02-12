using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Authentication;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.ViewModel;
using LocacaoVeiculosApi.Infra.Database;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public class UsuarioService
    {
        public UsuarioService(IUsuarioRepository repository){
          this.repository = repository;
        }

        public UsuarioService(UsuarioRepository userRepository)
        {
        }

        private IUsuarioRepository repository;

        public async Task<UsuarioJwt> Login(Usuario user, IToken token){
           var loggedUser = await repository.FindByLoginAndPassword(user.CpfMatricula, user.Senha);
           if(loggedUser == null) throw new UsuarioNotFound("Usuário e senha inválidos.");
           return new UsuarioJwt(){
             id = loggedUser.Id,
             login = loggedUser.CpfMatricula,
             userType = loggedUser.TipoUsuario.ToString(),
             Token = token.GerarToken(loggedUser)
           };
        }

        internal Task<ICollection<UsuarioView>> All()
        {
            throw new NotImplementedException();
        }
    }
}