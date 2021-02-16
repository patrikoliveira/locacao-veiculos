using System.Threading.Tasks;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}