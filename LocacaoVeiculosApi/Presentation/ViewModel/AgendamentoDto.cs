using System;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataHoraColetaPrevista { get; set; }
        public DateTime? DataHoraColetaRealizada { get; set; }
        public DateTime DataHoraEntregaPrevista { get; set; }
        public DateTime? DataHoraEntregaRealizada { get; set; }
        public double ValorHora { get; set; }
        public double HorasLocacao { get; set; }
        public double SubTotal { get; set; }
        public double? CustosAdicional { get; set; }
        public double? ValorTotal { get; set; }
        public bool? RealizadaVistoria { get; set; }

        public int? UsuarioId { get; set; }
        public int? OperadorId { get; set; }
        public int VeiculoId { get; set; }
        
        public int? ChecklistId { get; set; }
        public virtual ChecklistDto Checklist { get; set; }
    }
}