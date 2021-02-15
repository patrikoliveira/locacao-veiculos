using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Operador : Usuario, IOperador
    {
        [Column]
        [JsonIgnore]
        public override string CpfMatricula { get; set; }
        [Column]
        [JsonIgnore]
        public override int TipoUsuario { get; set; }

        [Column]
        [JsonIgnore]
        public override int? EnderecoId { get; set; }

        [Required]
        public string Matricula
        {
            get
            {
                return this.CpfMatricula;
            }
            set
            {
                this.CpfMatricula = value;
            }
        }

       /* public override TipoUsuario Tipo
        {
            get
            {
                return TipoUsuario.Operador;
            }
        }*/
    }
}