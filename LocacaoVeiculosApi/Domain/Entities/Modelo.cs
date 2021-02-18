using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    public class Modelo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}