namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public class OperadorService
    {
        public OperadorService(IOperadorRepository repository){
          this.repository = repository;
        }
        private IOperadorRepository repository;
    }
}