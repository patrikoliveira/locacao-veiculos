using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Endereco
{
	[Required]
	public string Cep { get; set; }
	public string Logradouro { get; set; }
	public int Numero { get; set; }
	public string Cidade { get; set; }
	public string Estado { get; set; }
}
