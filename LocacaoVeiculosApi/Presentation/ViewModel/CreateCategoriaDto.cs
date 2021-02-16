using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class CreateCategoriaDto
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}