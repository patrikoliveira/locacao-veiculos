using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services.Communication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Services
{
    public class LocacaoService
    {
        private readonly EntityRepository<Veiculo> _veiculoRepository;
        private readonly IMapper _mapper;

        public LocacaoService(EntityRepository<Veiculo> veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<DtoResponse<CalculoLocacaoDto>> Simular(CalcularLocacaoInput locacaoInput)
        {
            var veiculos = await _veiculoRepository.Filter(x => x.Id == locacaoInput.VeiculoId, v=>v.Marca, v=>v.Modelo, v=>v.Categoria);

            if (veiculos == null || veiculos.Count() == 0)
            {
                return new DtoResponse<CalculoLocacaoDto>("Veículo não encontrado");
            }

            var veiculo = veiculos.First();

            DateTime dataRetirada = DateTime.Parse(locacaoInput.DataRetirada);
            DateTime dataDevolucao = DateTime.Parse(locacaoInput.DataDevolucao);

            double totalHoras = dataDevolucao.Subtract(dataRetirada).TotalHours;

            return new DtoResponse<CalculoLocacaoDto>( new CalculoLocacaoDto()
            {
                Veiculo = _mapper.Map<Veiculo, VeiculoDto>(veiculo),
                Total = totalHoras * veiculo.ValorHora,
                DataDevolucao = dataDevolucao,
                DataRetirada = dataRetirada
            });
        }
    }
}