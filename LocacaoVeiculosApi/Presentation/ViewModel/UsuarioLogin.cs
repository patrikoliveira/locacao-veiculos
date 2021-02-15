namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record UsuarioLogin
    {
        public string CpfMatricula {get;set;}
        public string Senha {get;set;}   
    }
}