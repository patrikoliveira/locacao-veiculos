using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("modelos")]
    public class Modelo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}