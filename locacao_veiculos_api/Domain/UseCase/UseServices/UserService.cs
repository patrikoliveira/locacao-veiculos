using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locacao_veiculos_api.Domain.Authentication;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Domain.UseCase.UseServices
{
    public class UserService
    {
        public UserService(IUserRepository repository){
          this.repository = repository;
        }

        private IUserRepository repository;

        public async Task<UserJwt> Login(User user, IToken token){
           var loggedUser = await repository.FindByLoginAndPassword(user.login, user.password);
           if(loggedUser == null) throw new UserNotFound("Usuário e senha inválidos.");
           return new UserJwt(){
             id = loggedUser.id,
             login = loggedUser.login,
             userType = loggedUser.userType.ToString(),
             Token = token.GerarToken(loggedUser)
           };
        }
    }
}