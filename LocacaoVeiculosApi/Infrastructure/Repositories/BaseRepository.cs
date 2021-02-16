using LocacaoVeiculosApi.Infrastructure.Database;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly EntityContext _context;

        protected BaseRepository(EntityContext context)
        {
            _context = context;
        }
    }
}