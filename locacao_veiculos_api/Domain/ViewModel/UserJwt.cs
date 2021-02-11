namespace locacao_veiculos_api.Domain.ViewModel
{
    public record UserJwt
    {
        public int id { get; set; }
        public string login { get; set; }
        public string userType { get; set; }
        public string Token { get; set; }
    }
}