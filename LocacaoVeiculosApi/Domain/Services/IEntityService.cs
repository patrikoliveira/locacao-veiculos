using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services.Communication;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface IEntityService<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] includes);
        Task<EntityResponse> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<EntityResponse> CreateAsync(T entity);
        Task<EntityResponse> UpdateAsync(int id, T entity);
        Task<EntityResponse> DeleteAsync(int id);
    }
}