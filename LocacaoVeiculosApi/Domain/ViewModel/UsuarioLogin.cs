namespace LocacaoVeiculosApi.Domain.ViewModel
{
    public record UsuarioLogin
    {
        public string CpfMatricula {get;set;}
        public string Senha {get;set;}   
    }
}