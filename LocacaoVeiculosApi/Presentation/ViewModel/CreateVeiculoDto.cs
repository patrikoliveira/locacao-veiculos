using System.ComponentModel.DataAnnotations;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class CreateVeiculoDto
    {
        [Required]
        [StringLength(7)]
        public string Placa { get; set; }
        
        [Required]
        public int ModeloId { get; set; }
        
        [Required]
        public int MarcaId { get; set; }
        
        [Required]
        public int CategoriaId { get; set; }
        
        [Required]
        public Combustivel Combustivel { get; set; }
        
        [Required]
        public float ValorHora { get; set; }
        
        [Required]
        public int CapacidadePortaMalas { get; set; }
        
        [Required]
        public int CapacidadeTanque { get; set; }
    }
}