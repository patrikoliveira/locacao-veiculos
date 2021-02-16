using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    public class Veiculo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public int ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public Combustivel Combustivel { get; set; }
        public float ValorHora { get; set; }
        public int CapacidadePortaMalas { get; set; }
        public int CapacidadeTanque { get; set; }
    }
}