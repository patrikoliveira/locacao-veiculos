using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("endereco")]
public class Endereco
{
	[Key]
	[Column]
	[JsonIgnore]
	public int Id {get; set;}
	[Column]
	[Required]
	public string Cep { get; set; }
	[Column]
	[Required]
	public string Logradouro { get; set; }
	[Column]
	[Required]
	public int Numero { get; set; }
	[Column]
	public string Complemento {get; set;}
	[Column]
	[Required]
	public string Cidade { get; set; }
	[Column]
	[Required]
	[MaxLength(2)]
	public string Estado { get; set; }
}
