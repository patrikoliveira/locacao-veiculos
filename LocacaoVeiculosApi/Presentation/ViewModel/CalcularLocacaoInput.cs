using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class CalcularLocacaoInput
    {
        [Required]
        public int VeiculoId { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        public int OperadorId { get; set; }

        [Required]
        public string DataRetirada { get; set; }
        
        [Required]
        public string DataDevolucao { get; set; }
    }
}