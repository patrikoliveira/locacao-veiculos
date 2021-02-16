using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class CreateModeloDto
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}