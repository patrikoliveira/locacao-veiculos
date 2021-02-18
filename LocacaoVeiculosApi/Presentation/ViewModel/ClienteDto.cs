namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class ClienteDto
    {
        public int Id {get;set;}
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string DataNascimento { get; set; }
        public EnderecoDto Endereco {get;set;}
    }
}