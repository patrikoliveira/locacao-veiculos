using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task Save(Usuario Usuario);
        Task CountByCpfMatricula<T>(string cpfMatricula, TipoUsuario tipo);
        Task CountByIdAndCpfMatricula<T>(int id, string cpfMatricula, TipoUsuario tipo);
        Task<IUsuario> FindByLoginAndPassword<T>(string cpfMatricula, string senha, int tipoUsuario);
        Task<ICollection<T>> AllByType<T>(short tipoUsuario);
        Task Delete<T>(int id);
        Task All<T>(string v);
        Task AllByType<T>();
    }
}