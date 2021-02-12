using System;
using System.IO;
using System.Text;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infra.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;

namespace LocacaoVeiculosApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            //services.AddDbContext<EntityContext>(options => options.UseNpgsql(jAppSettings["ConnectionString"].ToString()));

            //var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
            
            services.AddControllersWithViews();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "locacao_veiculos_api", Version = "v1" });
            });

            services.AddMvc(config =>
            {
               var policy = new AuthorizationPolicyBuilder()
                               .RequireAuthenticatedUser()
                               .Build();
               config.Filters.Add(new AuthorizeFilter(policy));
            });

           /*services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });*/

            services.AddAuthorization(options =>
            {
               options.AddPolicy(TipoUsuario.Operador.ToString(), policy => policy.RequireClaim(TipoUsuario.Operador.ToString()));
               options.AddPolicy(TipoUsuario.Cliente.ToString(), policy => policy.RequireClaim(TipoUsuario.Cliente.ToString()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "locacao_veiculos_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

             app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
