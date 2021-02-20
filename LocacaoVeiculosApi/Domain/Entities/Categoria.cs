using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Domain.Entities
{
    public class Categoria : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}