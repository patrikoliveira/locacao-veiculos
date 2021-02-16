using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LocacaoVeiculosApi.Domain.Entities.Enums;
using LocacaoVeiculosApi.Domain.Entities.Exceptions;

namespace LocacaoVeiculosApi.Domain.Entities
{
    [Table("users")]
    public class Cliente : Usuario, ICliente
    {
        [Column]
        [JsonIgnore]
        public override string CpfMatricula { get; set; }
        [Column]
        [JsonIgnore]
        public override TipoUsuario TipoUsuario { get; set; }
        [Column]
        public string DataNascimento { get; set; }
        [Column]
        [JsonIgnore]
        public override int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        [Required]
        public string Cpf
        {
            get
            {
                if (!string.IsNullOrEmpty(this.CpfMatricula) && !IsCpfValido()) throw new CpfInvalidoException("CPF informado é inválido.");
                return this.CpfMatricula;
            }
            set
            {
                this.CpfMatricula = value;
            }
        }

        public override TipoUsuario Tipo
         {
             get{
                 return TipoUsuario.Cliente;
             }
         }

        private bool IsCpfValido()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            this.CpfMatricula = this.CpfMatricula.Trim();
            this.CpfMatricula = this.CpfMatricula.Replace(".", "").Replace("-", "");
            if (this.CpfMatricula.Length != 11)
                return false;
            tempCpf = this.CpfMatricula.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return this.CpfMatricula.EndsWith(digito);
        }

    }
}