namespace locacao_veiculos_api.Domain.ViewModel
{
    public record UsuarioView
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userType { get; set; }
    }
}