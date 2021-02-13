using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.ViewModel;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task Update(Usuario Usuario);
        Task Save(Usuario Usuario);
        Task Delete(Usuario Usuario);
        Task<ICollection<UsuarioView>> All();
        Task<Usuario> FindById(int id);
        Task<Usuario> FindByLoginAndPassword(string login, string password);
        Task CountByIdAndUser(int id, string cpfMatricula);
        Task CountByUser(string cpfMatricula);
    }
}