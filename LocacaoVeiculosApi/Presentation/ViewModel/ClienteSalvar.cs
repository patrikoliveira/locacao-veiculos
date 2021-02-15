namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record ClienteSalvar
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}