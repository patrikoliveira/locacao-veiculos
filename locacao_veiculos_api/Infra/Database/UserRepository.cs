using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace locacao_veiculos_api.Infra.Database
{
    public class UserRepository
    {   
        private readonly EntityContext context;
        public UserRepository(EntityContext context)
        {
          this.context = context;
        }
        public async Task<User> FindByLoginAndPassword(string login, string password)
        {
            return await context.Users.Where(u => u.login == login && u.password == password).FirstOrDefaultAsync();
        }
    }
}