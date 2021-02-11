using locacao_veiculos_api.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace locacao_veiculos_api.Controllers
{
    internal class HomeController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public Welcome Index()
        {
            return new Welcome();
        }
    }
}