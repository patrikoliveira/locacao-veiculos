using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services.Communication;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Services
{
    public class AgendamentoService
    {
        private readonly EntityRepository<Veiculo> _veiculoRepository;
        private readonly EntityRepository<Agendamento> _agendamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgendamentoService(EntityRepository<Veiculo> veiculoRepository, EntityRepository<Agendamento> agendamentoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _agendamentoRepository = agendamentoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DtoResponse<CalcularLocacaoResposta>> Simular(CalcularLocacaoInput locacaoInput)
        {
            var veiculos = await _veiculoRepository.Filter(x => x.Id == locacaoInput.VeiculoId, v=>v.Marca, v=>v.Modelo, v=>v.Categoria);

            if (veiculos == null || veiculos.Count() == 0)
            {
                return new DtoResponse<CalcularLocacaoResposta>("Veículo não encontrado");
            }

            var veiculo = veiculos.First();

            DateTime dataRetirada = DateTime.Parse(locacaoInput.DataRetirada);
            DateTime dataDevolucao = DateTime.Parse(locacaoInput.DataDevolucao);

            double totalHoras = dataDevolucao.Subtract(dataRetirada).TotalHours;

            return new DtoResponse<CalcularLocacaoResposta>( new CalcularLocacaoResposta()
            {
                Veiculo = _mapper.Map<Veiculo, VeiculoDto>(veiculo),
                Total = totalHoras * veiculo.ValorHora,
                TotalHoras = totalHoras,
                DataDevolucao = dataDevolucao,
                DataRetirada = dataRetirada
            });
        }

        public async Task<EntityResponse> Alugar(CalcularLocacaoInput input)
        {
            var agendamentos = await _agendamentoRepository.Filter(ag => ag.VeiculoId == input.VeiculoId && ag.DataHoraEntregaRealizada == null);

            if (agendamentos.Count() > 0)
            {
                return new EntityResponse("Veículo não está disponível");
            }

            var simularValor = await Simular(input);

            if (!simularValor.Success)
            {
                return new EntityResponse(simularValor.Message);
            }

            var simulado = simularValor.Entity;
            var agendamento = new Agendamento()
            {
                DataAgendamento = DateTime.Now,
                DataHoraColetaPrevista = DateTime.Parse(input.DataRetirada),
                DataHoraEntregaPrevista = DateTime.Parse(input.DataDevolucao),
                ValorHora = simulado.Veiculo.ValorHora,
                HorasLocacao = simulado.TotalHoras,
                SubTotal = simulado.Total,
                VeiculoId = simulado.Veiculo.Id,
            };
            
            try
            {
                await _agendamentoRepository.AddAsync(agendamento);
                await _unitOfWork.CompleteAsync();

                return new EntityResponse((IEntity) agendamento);
            }
            catch (Exception e)
            {
                return new EntityResponse($"Um erro ocorreu ao salvar um agendamento: {e.Message}");
            }
        }
    }
}