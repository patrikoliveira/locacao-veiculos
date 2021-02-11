namespace LocacaoVeiculosApi.Domain.ViewModel
{
    public record Welcome
    {
        public string Message
        { 
          get
          { 
            return "Teste API";
          }
        }

        public string Documentation
        { 
          get
          { 
            return "https://localhost:5001/swagger";
          }
        }

    }
}