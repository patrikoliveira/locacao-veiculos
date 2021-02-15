using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.Controllers;

namespace LocacaoVeiculosApi.Services
{
    public class EntityService
    {
        public EntityService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public EntityService(EntityRepository entityRepository)
        {
        }

        private IEntityRepository repository;

        public virtual async Task Save<T>(T entity)
        {
            await repository.Save(entity);
        }

        public async Task Delete<T>(int id)
        {
            if (id == 0) throw new UsuarioIdVazio("Id não pode ser vazio.");
            var user = await repository.FindById<T>(id);
            if (user == null) throw new UsuarioIdVazio("Registro não encontrado.");
            await repository.Delete(user);
        }

        public async Task<ICollection<T>> All<T>()
        {
           return await repository.All<T>();
        }
    }
}