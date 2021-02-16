using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("modelos")]
    public class Modelo : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; }
    }
}