using System;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infrastructure.PdfService;

namespace LocacaoVeiculosApi.Services
{
    public class PdfService
    {
        public PdfService(IGeraPdf pdfWriter)
        {
            this.pdfWriter = pdfWriter;
        }

        public IGeraPdf pdfWriter { get; }

        public async Task<string> ContratoAluguelPdf(Agendamento agendamento, IEntityRepository entityRepository, string path)
        {
            var veiculo = await entityRepository.FindById<Veiculo>(agendamento.VeiculoId);
            var categoria = await entityRepository.FindById<Categoria>(veiculo.CategoriaId);
            var modelo = await entityRepository.FindById<Modelo>(veiculo.ModeloId);
            var marca = await entityRepository.FindById<Marca>(veiculo.MarcaId);

            var body = "<hr>";
            body += "<h3>Reserva</h3>";
            body += "<hr>";
            body += $"Data da reserva: {agendamento.DataAgendamento:dd/mm/yyyy HH:MM}<br>";
            body += $"Quantidade de horas alugadas: {agendamento.HorasLocacao}<br>";
            body += $"Data da coleta prevista: {agendamento.DataHoraColetaPrevista:dd/mm/yyyy HH:MM}<br>";
            body += $"Data de entrega prevista: {agendamento.DataHoraEntregaPrevista:dd/mm/yyyy HH:MM}<br>";
            body += $"Valor da hora: R${agendamento.ValorHora}";
            body += "<hr>";
            body += "<h3>Reserva do veículo</h3>";
            body += "<hr>";
            body += $"Placa: {veiculo.Placa}<br>";
            body += $"Marca: {marca.Nome}<br>";
            body += $"Modelo: {modelo.Nome}<br>";
            body += $"Categoria: {categoria.Nome}<br>";
            body += $"Capacidade do tanque: {veiculo.CapacidadeTanque}<br>";
            body += $"Capacidade do Porta Malas: {veiculo.CapacidadePortaMalas}";
            body += "<hr>";
            body += $"<h2>Valor Estimado: R${agendamento.SubTotal}</h2>";
            body += "<hr>";

            return pdfWriter.Build(path, body);
        }

        public async Task<string> ContratoPagamentoPdf(Agendamento agendamento, IEntityRepository entityRepository, string path)
        {
            var veiculo = await entityRepository.FindById<Veiculo>(agendamento.VeiculoId);
            var categoria = await entityRepository.FindById<Categoria>(veiculo.CategoriaId);
            var modelo = await entityRepository.FindById<Modelo>(veiculo.ModeloId);
            var marca = await entityRepository.FindById<Marca>(veiculo.MarcaId);
            var checklist = agendamento.Checklist;

            var body = "<hr>";
            body += "<h3>Reserva</h3>";
            body += "<hr>";
            body += $"Data da reserva: {agendamento.DataAgendamento:dd/mm/yyyy HH:MM}<br>";
            body += $"Quantidade de horas alugadas: {agendamento.HorasLocacao}<br>";
            body += $"Data da coleta prevista: {agendamento.DataHoraColetaPrevista:dd/mm/yyyy HH:MM}<br>";
            body += $"Data de entrega prevista: {agendamento.DataHoraEntregaPrevista:dd/mm/yyyy HH:MM}<br>";
            body += $"Valor da hora: R${agendamento.ValorHora}";
            body += "<hr>";
            body += "<h3>Dados da entrega</h3>";
            body += "<hr>";
            body += $"Data da coleta: {agendamento.DataHoraColetaRealizada:dd/mm/yyyy HH:MM}<br>";
            body += $"Data da entrega: {agendamento.DataHoraEntregaRealizada:dd/mm/yyyy HH:MM}";
            body += "<hr>";
            body += "<h3>Checklist</h3>";
            body += "<hr>";
            body += $"Carro limpo: {(checklist.CarroLimpo ? "Sim" : "Não")}<br>";
            body += $"Tanque cheio: {(checklist.TanqueCheio ? "Sim" : "Não")}<br>";
            body += $"Tanque litro pendente: {(checklist.TanqueLitroPendente)} Litros<br>";
            body += $"Amassado: {(checklist.Amassados ? "Sim" : "Não")}<br>";
            body += $"Arranhões: {(checklist.Arranhoes ? "Sim" : "Não")}";
            body += "<hr>";
            body += "<h3>Reserva do veículo</h3>";
            body += "<hr>";
            body += $"Placa: {veiculo.Placa}<br>";
            body += $"Marca: {marca.Nome}<br>";
            body += $"Modelo: {modelo.Nome}<br>";
            body += $"Categoria: {categoria.Nome}<br>";
            body += $"Capacidade do tanque: {veiculo.CapacidadeTanque}<br>";
            body += $"Capacidade do Porta Malas: {veiculo.CapacidadePortaMalas}";
            body += "<hr>";
            body += $"<h3>Valor Estimado: R${agendamento.SubTotal}</h3>";
            body += $"<h2>Valor Total: R${agendamento.ValorTotal}</h2>";
            body += "<hr>";

            return pdfWriter.Build(path, body);
        }
    }
}