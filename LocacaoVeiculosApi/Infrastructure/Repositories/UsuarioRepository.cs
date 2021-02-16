using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Infrastructure.Database;
using LocacaoVeiculosApi.Domain.Repositories;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class UsuariosRepository<T> : BaseRepository, IUsuarioRepository<T> where T : class
    {
        public UsuariosRepository(EntityContext context) : base(context)
        {
        }

        public async Task<Usuario> FindByLoginAndPassword(string login, string password)
        {
            return await _context.Usuarios.Where(u => u.CpfMatricula == login && u.Senha == password).FirstOrDefaultAsync();
        }

        public async Task Save(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario user)
        {
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UsuarioView>> All()
        {
            return await _context.Usuarios.Select(u => new UsuarioView
            {
                Id = u.Id,
                CpfMatricula = u.CpfMatricula,
                Nome = u.Nome,
                TipoUsuario = u.TipoUsuario.ToString()
            }).ToListAsync();
        }

        public async Task Delete(Usuario user)
        {
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}