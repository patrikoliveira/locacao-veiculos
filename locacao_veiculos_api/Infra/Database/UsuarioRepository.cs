using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Infra.Database
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