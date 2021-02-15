using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Domain.UseCase.UseServices;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using System;

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

        public async Task<UsuarioJwt> Login(Usuario user, Token token)
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
                if (size > 0) throw new UsuarioUnico("Documento já cadastrado."); 
                await repository.Save(user);
            }
            else
            {
                var size = await repository.CountByIdAndCpfMatricula<Usuario>(user.Id, user.CpfMatricula, user.Tipo);
                if (size > 0) throw new UsuarioUnico("Documento já cadastrado.");
                await repository.Update(user);
            }
        }

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