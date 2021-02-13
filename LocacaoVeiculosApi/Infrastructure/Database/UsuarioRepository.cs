using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.ViewModel;

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
            return await context.Users.Where(u => u.CpfMatricula == login && u.Senha == password).FirstOrDefaultAsync();
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

        public async Task<ICollection<UsuarioView>> All()
        {
            return await context.Users.Select( u => new UsuarioView {
                        Id = u.Id,
                        CpfMatricula = u.CpfMatricula,
                        Nome = u.Nome,
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