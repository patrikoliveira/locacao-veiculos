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

        // public async Task<ICollection<T>> AllByType<T>(short tipoUsuario) {
        //     // return await _context.Set<T>().All();
        //     return null;
        // }

        // public async Task<IEnumerable<IEntity>> ListAsync()
        // {
        //     return await _context.Usuarios.ToListAsync();
        // }
        // Task AddAsync<Usuario>(Usuario entity) where Usuario : class;
        // public async Task AddAsync<Usuario>(Usuario entity)
        // {
        //     await _context.Usuarios.AddAsync(usuario);
        // }
        // public async Task<Usuario> FindByIdAsync(int id)
        // {
        //     return await _context.Usuarios.FindAsync(id);
        // }
        // public Task Update<Usuario>(Usuario user)
        // {
        //     _context.Usuarios.Update(entity);
        // }
        // public void Remove(Usuario entity)
        // {
        //     _context.Usuarios.Remove(entity);
        // }

        // public async Task<IUsuario> FindByLoginAndPassword<T>(string login, string password)
        // {
        //     return await _context.Usuarios.Where(u => u.CpfMatricula == login && u.Senha == password).FirstOrDefaultAsync();
        // }

        // public async Task<ICollection<UsuarioView>> All()
        // {
        //     return await _context.Usuarios.Select(u => new UsuarioView
        //     {
        //         Id = u.Id,
        //         CpfMatricula = u.CpfMatricula,
        //         Nome = u.Nome,
        //         TipoUsuario = u.TipoUsuario.ToString()
        //     }).ToListAsync();
        // }

        // public async Task Save<Usuario>(Usuario user)
        // {
        //     return null;
        // }
        // public async Task CountByCpfMatricula<T>(string cpfMatricula, short tipo)
        // {
        //     return null;
        // }

        // public async Task CountByIdAndCpfMatricula<T1>(int id, string cpfMatricula, string tipoUsuario)
        // {
        //     return null;
        // }
        

    }
}