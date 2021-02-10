namespace locacao_veiculos_api.Infra.Database
{
    public class UserRepository
    {   
        private readonly EntityContext context;
        public UserRepository(EntityContext context)
        {
          this.context = context;
        }
    }
}