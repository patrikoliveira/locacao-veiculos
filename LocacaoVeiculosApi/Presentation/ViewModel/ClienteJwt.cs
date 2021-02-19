namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class ClienteJwt
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string TipoUsuario { get; set; }
        public string Token { get; set; }
    }
}