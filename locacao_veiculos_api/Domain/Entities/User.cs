namespace locacao_veiculos_api.Domain.Entities
{
    public class User
    {
        public int id {get;set;}
        public string login {get;set;}
        public string password {get;set;}
        public UserType userType {get;set;}
    }
}