using System;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Authentication;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;

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

        internal Task<object> Login(UsuarioLogin userLogin, Token token)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> RetornaTodosUsuarios()
        {
            return repository.All();
        }

       /* public async Task Save(Usuario user) 
        {
            if (user.TipoUsuario == null) user.TipoUsuario = OPERADOR;

            if (user.TipoUsuario == 1){
                if (user.Endereco.ToString().IsNotNullOrEmpty<Usuario>){
                 var size = await repository.CountByIdAndUser(user.Id, user.CpfMatricula);
                  if(size > 0) throw new UsuarioUnico("CPF já cadastrado.");
                    await repository.Save(user);
                }
            }
            else if (user.TipoUsuario == 2){
             var size = await repository.CountByUser(user.CpfMatricula);
              if(size > 0) throw new UsuarioUnico("Matrícula já cadastrada.");
                await repository.Save(user);
            }
        }*/

        public async Task Delete(int id)
        {
          if(id == 0) throw new UsuarioIdVazio("Id não pode ser vazio");
          var user = await repository.FindById(id);
          if(user == null) throw new UsuarioNotFound("Usuário não encontrado");
          await repository.Delete(user);
        }
        
        public async Task Update(Usuario user)
        {
            //TODO
            var usurioAlteracao = await repository.FindById(user.Id);
            if (usurioAlteracao == null || usurioAlteracao.Id == 0) throw new UsuarioNotFound("Usuário não encontrado");

         /* var address = EntityBuilder.Call<Address>(completeUser);
                var userBuilder = EntityBuilder.Call<Usuario>(completeUser);
                userBuilder.Id = usurioAlteracao.Id;
                userBuilder.IdAddress = usurioAlteracao.IdAddress;
                address.Id = Convert.ToInt32(usurioAlteracao.IdAddress);
                
                var size = await personRepository.CountByIdAndDocument<Usuario>(userBuilder.Id, userBuilder.CPF, Convert.ToInt16(userBuilder.Role));
*/
                //await repository.Update(address);
                await repository.Update(user);
        }



    }
}