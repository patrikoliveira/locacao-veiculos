using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task Update(Usuario Usuario);
        Task Save(Usuario Usuario);
        Task Delete(Usuario Usuario);
        Task<Usuario> All();
        Task<Usuario> FindById(int id);
        Task<Usuario> FindByLoginAndPassword(string login, string password);
        Task CountByIdAndUser(int id, string cpfMatricula);
        Task CountByUser(string cpfMatricula);
        Task CountByCpfMatricula<T>(string cpfMatricula, TipoUsuario tipo);
        Task CountByIdAndCpfMatricula<T>(int id, string cpfMatricula, TipoUsuario tipo);
    }
}