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
        // private readonly IUnitOfWork _unitOfWork;

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

        // public async Task<ICollection<T>> RetornaTodosUsuarioPorTipo<T>(TipoUsuario tipo)
        // {
        //     return await _usuarioRepository.AllByType<T>(Convert.ToInt16(tipo));
        // }

        // public async Task<IEnumerable<UsuarioView>> RetornaTodosUsuarios()
        // {
        //     var todosUsuarios = await _usuarioRepository.All();
        //     return todosUsuarios;
        //    /* var usuario = new List<Usuario>();
        //     foreach (var usuarioCompleto in todosUsuarios)
        //     {
        //         var user = EntityBuilder.Call<Usuario>(usuarioCompleto);
        //         user.EndrecoId = EntityBuilder.Call<Endereco>(usuarioCompleto);
        //         usuario.Add(user);
        //     }
        //     return usuario;*/
        // }

        //  public async Task Save(UsuarioView user)
        // {
        //     if (user.Id == 0)
        //     {
        //         if (user.TipoUsuario == 0) user.TipoUsuario = Convert.ToInt16(user.TipoUsuario);
        //         var size = await _usuarioRepository.CountByCpfMatricula<Usuario>(user.CpfMatricula, user.TipoUsuario);
        //         if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
        //         await _usuarioRepository.Save(user);
        //     }
        //     else
        //     {
        //         var size = await _usuarioRepository.CountByIdAndCpfMatricula<Usuario>(user.Id, user.CpfMatricula, user.TipoUsuario);
        //         if (size > 0) throw new UsuarioUnico("Login já cadastrado.");
        //         await _usuarioRepository.Update(user);
        //     }
        // }

        // public async Task<UsuarioResponse> CreateAsync(UsuarioView entity)
        // {
        //     try
        //     {
        //         await _usuarioRepository.AddAsync(entity);
        //         await _unitOfWork.CompleteAsync();

        //         return new UsuarioResponse(entity);
        //     }
        //     catch (Exception e)
        //     {
        //         return new UsuarioResponse($"Um erro ocorreu ao salvar o usuário: {e.Message}");
        //     }
        // }

        // public async Task<UsuarioResponse> UpdateAsync(int id, UsuarioView entity)
        // {
        //     var usuarioExistente = await _usuarioRepository.FindByIdAsync(id);

        //     if (usuarioExistente == null)
        //     {
        //         return new UsuarioResponse("Usuário não encontrada.");
        //     }

        //     usuarioExistente.Nome = entity.Nome;

        //     try
        //     {
        //         _usuarioRepository.Update(usuarioExistente);
        //         await _unitOfWork.CompleteAsync();

        //         return new UsuarioResponse(usuarioExistente);
        //     }
        //     catch (Exception e)
        //     {
        //         return new UsuarioResponse($"Um erro ocorreu ao atualizar a categoria: {e.Message}");
        //     }
        // }

        // public async Task<IEnumerable<IEntity>> ListAsync()
        // {
        //     return await _usuarioRepository.ListAsync();
        // }

        // public async Task<UsuarioResponse> CreateAsync(Usuario entity)
        // {
        //     try
        //     {
        //         await _usuarioRepository.AddAsync(entity);
        //         await _unitOfWork.CompleteAsync();

        //         return new UsuarioResponse(entity);
        //     }
        //     catch (Exception e)
        //     {
        //         return new UsuarioResponse($"Um erro ocorreu ao salvar o usuário: {e.Message}");
        //     }
        // }

        // public async Task<UsuarioResponse> DeleteAsync(int id)
        // {
        //     var usuarioExistente = await _usuarioRepository.FindByIdAsync(id);
        //     if (usuarioExistente == null)
        //         return new UsuarioResponse("Usuário não encontrado.");

        //     try
        //     {
        //         _usuarioRepository.Remove(usuarioExistente);
        //         await _unitOfWork.CompleteAsync();
        //         return new UsuarioResponse(usuarioExistente);
        //     }
        //     catch (Exception e)
        //     {
        //         return new UsuarioResponse($"Um erro ocorreu ao deletar o usuário: {e.Message}");
        //     }
        // }
    }
}