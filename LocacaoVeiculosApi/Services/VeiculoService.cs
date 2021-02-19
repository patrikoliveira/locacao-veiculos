using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Services
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _veiculoRepository;
        
        public VeiculoService(VeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
        
        public async Task<IEnumerable<VeiculoOutputRepository>> GetVeiculosDisponiveisAsync()
        {
            return await _veiculoRepository.GetVeiculosDisponiveisAsync();
        }
    }
}