using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IUsuarioRepository<T> where T : class
    {
        Task<Usuario> FindByLoginAndPassword(string login, string password);
        Task Save(Usuario user);
        Task Update(Usuario user);
        Task<ICollection<UsuarioView>> All();
        Task Delete(Usuario user);
        Task<ICollection<T>> AllByType<T>(short tipoUsuario);
        Task FindByIdAsync(int id);
    }
}