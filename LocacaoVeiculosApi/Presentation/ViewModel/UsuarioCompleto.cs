namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record UsuarioCompleto
    {
        public string Id {get;set;}
         public string CpfMatricula {get;set;}
        public string Senha {get;set;}
        public string Nome {get;set;}
        public string DataNascimento{get;set;}
        public int EnderecoId {get;set;}

        public EnderecoDto Endereco { get; set; }
    }
}