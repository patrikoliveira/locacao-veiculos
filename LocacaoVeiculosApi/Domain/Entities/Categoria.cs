using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("categorias")]
    public class Categoria : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; }

        public IList<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}