using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IUsuarioRepository<T> where T : class
    {
        // Task<ICollection<UsuarioView>> All();
        // Task<ICollection<T>> AllByType<T>(short tipoUsuario);
        // Task<Usuario> FindByIdAsync(int id);
        // Task<IUsuario> FindByLoginAndPassword<T>(string login, string password);
        // Task AddAsync<Usuario>(Usuario entity) where Usuario : class;
        // Task Update<Usuario>(Usuario user) where Usuario : class;
        // Task Save<Usuario>(Usuario user) where Usuario : class;
        // Task CountByCpfMatricula<T>(string cpfMatricula, short tipo);
        // Task<IEnumerable<IEntity>> ListAsync();
        // Task CountByIdAndCpfMatricula<T1>(int id, string cpfMatricula, string tipoUsuario);
    }
}