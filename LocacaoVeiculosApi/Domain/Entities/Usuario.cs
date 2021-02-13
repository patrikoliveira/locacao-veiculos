using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Usuario
    {
        [Key]
		[Column]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
		[Column]
        [MaxLength(11)]
        public string CpfMatricula { get; set; }
        [Required]
		[Column]
        public string Senha { get; set; }
        [Required]
		[Column]
        public string Nome { get; set; }
		[Column]
        public virtual int? EnderecoId { get; set; }
        [Required]
        public virtual int TipoUsuario { get; set; }

        public virtual TipoUsuario Tipo { get { return (TipoUsuario)Enum.ToObject(typeof(TipoUsuario), this.Tipo); } }
        
    }
}