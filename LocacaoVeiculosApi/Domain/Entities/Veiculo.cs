using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("veiculos")]
    public class Veiculo : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("placa")]
        public string Placa { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Combustivel Combustivel { get; set; }
        [Column("valor_hora")]
        public float ValorHora { get; set; }
        [Column("capacidade_porta_malas")]
        public int CapacidadePortaMalas { get; set; }
        [Column("capacidade_tanque")]
        public int CapacidadeTanque { get; set; }
    }
}