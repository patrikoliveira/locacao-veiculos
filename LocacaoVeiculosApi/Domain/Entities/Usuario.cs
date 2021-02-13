using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Usuario
    {
        [Key]
        [JsonIgnore]
        public int Id {get;set;}
        [Required]
        public string CpfMatricula {get;set;}
        [Required]
        public string Senha {get;set;}
        public string Nome {get;set;}
        public Endereco Endereco {get;set;}
        public TipoUsuario TipoUsuario {get;set;}


         public static bool IsCpfValido(string cpf){
		int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		string tempCpf;
		string digito;
		int soma;
		int resto;
		cpf = cpf.Trim();
		cpf = cpf.Replace(".", "").Replace("-", "");
		if (cpf.Length != 11)
		   return false;
		tempCpf = cpf.Substring(0, 9);
		soma = 0;

		for(int i=0; i<9; i++)
		    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		resto = soma % 11;
		if ( resto < 2 )
		    resto = 0;
		else
		   resto = 11 - resto;
		digito = resto.ToString();
		tempCpf = tempCpf + digito;
		soma = 0;
		for(int i=0; i<10; i++)
		    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		resto = soma % 11;
		if (resto < 2)
		   resto = 0;
		else
		   resto = 11 - resto;
		digito = digito + resto.ToString();
		return cpf.EndsWith(digito);
        }
    }
}