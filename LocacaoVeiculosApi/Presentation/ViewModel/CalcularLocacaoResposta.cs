using System;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class CalculoLocacaoDto
    {
        public VeiculoDto Veiculo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Total { get; set; }
    }
}