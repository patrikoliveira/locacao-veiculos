using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using LocacaoVeiculosApi.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Services;
using LocacaoVeiculosApi.Presentation.ViewModel;
using AutoMapper;

namespace LocacaoVeiculosApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : Controller
    {
        
    }
}