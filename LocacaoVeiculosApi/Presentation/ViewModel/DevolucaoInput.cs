using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class DevolucaoInput
    {
        [Required]
        public bool CarroLimpo { get; set; }
        
        [Required]
        public bool TanqueCheio { get; set; }
        
        [Required]
        public int TanqueLitroPendente { get; set; }
        
        [Required]
        [DefaultValue(false)]
        public bool Amassados { get; set; }

        [Required] 
        [DefaultValue(false)]
        public bool Arranhoes { get; set; } = false;
        
        [Required]
        public int AgendamentoId { get; set; }
        
        [Required]
        public int OperadorId { get; set; }
    }
}