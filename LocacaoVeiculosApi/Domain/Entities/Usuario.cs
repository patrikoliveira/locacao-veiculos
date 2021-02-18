using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Usuario : IEntity
    {
        [Key]
		[Column]
        [JsonIgnore]
        public virtual int Id { get; set; }
        [Required]
		[Column]
        [MaxLength(11)]
        public virtual string CpfMatricula { get; set; }
        [Required]
		[Column]
        public virtual string Senha { get; set; }
        [Required]
		[Column]
        public virtual string Nome { get; set; }
		[Column]
        public virtual int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        [Required]
        public virtual TipoUsuario TipoUsuario { get; set; }
        [Column]
        public virtual string DataNascimento { get; set; }

        public virtual TipoUsuario Tipo { get { return (TipoUsuario)Enum.ToObject(typeof(TipoUsuario), this.TipoUsuario); } }
        
    }
}