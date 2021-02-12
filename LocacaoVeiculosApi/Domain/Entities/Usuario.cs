using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Usuario
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public string CpfMatricula {get;set;}
        [Required]
        public string senha {get;set;}
        public string Nome {get;set;}
        public Endereco Endereco {get;set;}
        public TipoUsuario TipoUsuario {get;set;}
    }
}