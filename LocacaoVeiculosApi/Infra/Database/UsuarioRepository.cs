using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Infra.Database
{
    public class UsuarioRepository
    {   
        private readonly EntityContext context;
        public UsuarioRepository(EntityContext context)
        {
          this.context = context;
        }
        public async Task<Usuario> FindByLoginAndPassword(string login, string password)
        {
            return await context.Users.Where(u => u.Login == login && u.senha == password).FirstOrDefaultAsync();
        }
    }
}