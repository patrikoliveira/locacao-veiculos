using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class VeiculoRepository<T> : BaseRepository, IVeiculoRepository<T> where T : class
    {
        public VeiculoRepository(EntityContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IEntity>> ListAsync()//passar ListAsync<T> para deixar de modo generico
        {
            // return await _context.Set<Veiculo>().ToListAsync();
            return await _context.Veiculos.ToListAsync();
        }
    }
}