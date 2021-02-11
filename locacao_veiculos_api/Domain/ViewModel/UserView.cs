namespace locacao_veiculos_api.Domain.ViewModel
{
    public record UserView
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userType { get; set; }
    }
}