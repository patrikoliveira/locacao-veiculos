using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("categorias")]
    public class Categoria : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}