using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Domain.Services.Communication;

namespace LocacaoVeiculosApi.Services
{
    
    public class CategoriaService<T> : ICategoriaService<T> where T : class
    {
        private readonly ICategoriaRepository<Categoria> _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(ICategoriaRepository<Categoria> categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IEntity>> ListAsync()
        {
            return await _categoriaRepository.ListAsync();
        }

        public async Task<CategoriaResponse> GetAsync(int id)
        {
            var categoriaExistente = await _categoriaRepository.FindByIdAsync(id);

            if (categoriaExistente == null)
            {
                return new CategoriaResponse("Categoria não encontrada.");
            }
            
            return new CategoriaResponse(categoriaExistente);
        }


        public async Task<CategoriaResponse> CreateAsync(Categoria entity)
        {
            try
            {
                await _categoriaRepository.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(entity);
            }
            catch (Exception e)
            {
                return new CategoriaResponse($"Um erro ocorreu ao salvar a categoria: {e.Message}");
            }
        }

        public async Task<CategoriaResponse> UpdateAsync(int id, Categoria entity)
        {
            var categoriaExistente = await _categoriaRepository.FindByIdAsync(id);

            if (categoriaExistente == null)
            {
                return new CategoriaResponse("Categoria não encontrada.");
            }

            categoriaExistente.Nome = entity.Nome;

            try
            {
                _categoriaRepository.Update(categoriaExistente);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(categoriaExistente);
            }
            catch (Exception e)
            {
                return new CategoriaResponse($"Um erro ocorreu ao atualizar a categoria: {e.Message}");
            }
        }

        public async Task<CategoriaResponse> DeleteAsync(int id)
        {
            var categoriaExistente = await _categoriaRepository.FindByIdAsync(id);

            if (categoriaExistente == null)
                return new CategoriaResponse("Categoria não encontrada.");

            try
            {
                _categoriaRepository.Remove(categoriaExistente);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(categoriaExistente);
            }
            catch (Exception e)
            {
                return new CategoriaResponse($"Um erro ocorreu ao deletar a categoria: {e.Message}");
            }
        }
    }
}