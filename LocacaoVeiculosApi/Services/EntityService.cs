using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Domain.Services.Communication;
using LocacaoVeiculosApi.Extensions;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using Neo4jClient.DataAnnotations.Cypher.Functions;

namespace LocacaoVeiculosApi.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        private readonly EntityRepository<T> _entityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EntityService(EntityRepository<T> entityRepository, IUnitOfWork unitOfWork)
        {
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _entityRepository.ListAsync();
        }

        public async Task<EntityResponse> GetAsync(int id)
        {
            var entityExistente = await _entityRepository.FindByIdAsync(id);
            
            if (entityExistente == null)
            {
                return new EntityResponse("Categoria não encontrada.");
            }
            
            return new EntityResponse((IEntity) entityExistente);
        }

        public async Task<EntityResponse> CreateAsync(T entity)
        {
            try
            {
                await _entityRepository.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new EntityResponse((IEntity) entity);
            }
            catch (Exception e)
            {
                return new EntityResponse($"Um erro ocorreu ao salvar a {entity.GetType().Name}: {e.Message}");
            }
        }
        
        private static void PropertySet(object p, string propName, object value)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
                return;
            if (!info.CanWrite)
                return;
            info.SetValue(p, value, null);
        }

        public async Task<EntityResponse> UpdateAsync(int id, T entity)
        {
            var entityExistente = await _entityRepository.FindByIdAsync(id);

            if (entityExistente == null)
            {
                return new EntityResponse($"{entity.GetType().Name} não encontrada.");
            }


            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.Name != "Id")
                {
                    PropertySet(entityExistente, prop.Name, prop.GetValue(entity, null));
                }
            }
            
            try
            {
                _entityRepository.Update(entityExistente);
                await _unitOfWork.CompleteAsync();

                return new EntityResponse((IEntity) entityExistente);
            }
            catch (Exception e)
            {
                return new EntityResponse($"Um erro ocorreu ao atualizar a {entity.GetType().Name}: {e.Message}");
            }
        }

        public async Task<EntityResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}