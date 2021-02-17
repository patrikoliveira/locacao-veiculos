using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Domain.Entities
{
    public class Checklist : IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool CarroLimpo { get; set; }
        public bool TanqueCheio { get; set; }
        public int TanqueLitroPendente { get; set; }
        public bool Amassados { get; set; }
        public bool Arranhoes { get; set; }
    }
}