using System.Threading.Tasks;
using locacao_veiculos_api.Domain.Authentication;
using locacao_veiculos_api.Domain.Entities;
using locacao_veiculos_api.Domain.ViewModel;
using locacao_veiculos_api.Infra.Database;

namespace locacao_veiculos_api.Domain.UseCase.UseServices
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
           var loggedUser = await repository.FindByLoginAndPassword(user.Login, user.senha);
           if(loggedUser == null) throw new UserNotFound("Usuário e senha inválidos.");
           return new UsuarioJwt(){
             id = loggedUser.Id,
             login = loggedUser.Login,
             userType = loggedUser.TipoUsuario.ToString(),
             Token = token.GerarToken(loggedUser)
           };
        }
    }
}