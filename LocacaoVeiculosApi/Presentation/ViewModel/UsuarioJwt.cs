namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record UsuarioJwt
    {
        public int id { get; set; }
        public string login { get; set; }
        public string userType { get; set; }
        public string Token { get; set; }
    }
}