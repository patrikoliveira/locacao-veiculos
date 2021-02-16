using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services;

namespace LocacaoVeiculosApi.Services
{
    public class VeiculoService<Veiculo> : IVeiculoService<Veiculo> where Veiculo : class
    {
        private readonly IVeiculoRepository<Veiculo> _veiculoRepository;

        public VeiculoService(IVeiculoRepository<Veiculo> veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<IEntity>> ListAsync()
        {
            return await _veiculoRepository.ListAsync();
        }
    }
}