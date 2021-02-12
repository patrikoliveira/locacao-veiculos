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

        public async Task Save(Usuario user)
        {
          context.Users.Add(user);
          await context.SaveChangesAsync(); 
        }

         public async Task Update(Usuario user)
        {
          context.Users.Update(user);
          await context.SaveChangesAsync(); 
        }

        public async Task<ICollection<UserView>> All()
        {
            return await context.Users.Select( u => new UsuarioView {
                        Id = u.Id,
                        CpfMatricula = u.CpfMatricula,
                        Nome = u.Nome,
                        Endereco = u.Endereco;
                        TipoUsuario = u.TipoUsuario.ToString()
                    }).ToListAsync();
        }

         public async Task Delete(Usuario user)
        {
          context.Users.Remove(user);
          await context.SaveChangesAsync(); 
        }

    }
}