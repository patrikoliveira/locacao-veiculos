namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record OperadorJwt
    {
        public int id {get;set;}
        public string nome {get;set;}
        public string tipoUsuario {get;set;}
        public string Matricula { get; internal set; }
        public string Token { get; internal set; }
    }
}