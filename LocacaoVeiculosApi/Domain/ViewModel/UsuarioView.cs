namespace LocacaoVeiculosApi.Domain.ViewModel
{
    public record UsuarioView
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userType { get; set; }
    }
}