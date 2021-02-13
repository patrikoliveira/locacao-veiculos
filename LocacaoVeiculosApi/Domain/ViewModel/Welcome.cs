namespace LocacaoVeiculosApi.Domain.ViewModel
{
    public record Welcome
    {
        public string Message
        { 
          get
          { 
            return "API Locação de Veículos";
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