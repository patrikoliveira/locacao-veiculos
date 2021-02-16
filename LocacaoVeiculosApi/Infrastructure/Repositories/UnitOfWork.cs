using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Infrastructure.Database;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;

        public UnitOfWork(EntityContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}