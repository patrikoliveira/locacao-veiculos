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
        private readonly EntityRepository<Checklist> _checklistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgendamentoService(EntityRepository<Veiculo> veiculoRepository, EntityRepository<Agendamento> agendamentoRepository, EntityRepository<Checklist> checklistRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _agendamentoRepository = agendamentoRepository;
            _checklistRepository = checklistRepository;
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

        public async Task<EntityResponse> Devolver(DevolucaoInput resource)
        {
            var agendamento = await _agendamentoRepository.FindByIdAsync(resource.AgendamentoId);

            if (agendamento == null)
            {
                return new EntityResponse("Agendamento não encontrado");
            }
            
            //TODO: Validar operador quando disponível
            // if (resource.OperadorId == 0)
            // {
            //     return new EntityResponse("Operador Obrigatório");
            // }
            
            var checklist = _mapper.Map<DevolucaoInput, Checklist>(resource);
            
            agendamento.DataHoraEntregaRealizada = DateTime.Now;

            double adicional = 0;

            if (!resource.CarroLimpo)
            {
                adicional += agendamento.SubTotal * 0.30;
            }
            
            if (!resource.TanqueCheio)
            {
                adicional += agendamento.SubTotal * 0.30;
            }
            
            if (resource.Amassados)
            {
                adicional += agendamento.SubTotal * 0.30;
            }
            
            if (resource.Arranhoes)
            {
                adicional += agendamento.SubTotal * 0.30;
            }

            agendamento.CustosAdicional = adicional;
            agendamento.ValorTotal = agendamento.SubTotal + adicional;
            agendamento.RealizadaVistoria = true;

            try
            {
                await _checklistRepository.AddAsync(checklist);
                await _unitOfWork.CompleteAsync();

                agendamento.ChecklistId = checklist.Id;
                _agendamentoRepository.Update(agendamento);
                await _unitOfWork.CompleteAsync();
                
                return new EntityResponse(agendamento);
            }
            catch (Exception e)
            {
                return new EntityResponse($"Um erro ocorreu ao atualizar um agendamento: {e.Message}");
            }
        }
    }
}