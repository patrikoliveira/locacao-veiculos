using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using Microsoft.IdentityModel.Tokens;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Domain.Authentication
{
    public interface IToken
    {
                string GerarToken(User user);
    }
}