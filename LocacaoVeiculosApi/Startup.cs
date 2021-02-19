using System;
using System.IO;
using System.Text;
using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Domain.Services;
using LocacaoVeiculosApi.Infrastructure.Database;
using LocacaoVeiculosApi.Infrastructure.Repositories;
using LocacaoVeiculosApi.Presentation.ViewModel;
using LocacaoVeiculosApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        public static string ContentRoot;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            //services.AddDbContext<EntityContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));

            var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());

           services.AddAuthentication(x =>
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
            });
            
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDbContext<EntityContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocacaoVeiculosApi", Version = "v1" });
            });

            services.AddScoped<EntityRepository<Categoria>>();
            services.AddScoped<EntityService<Categoria>>();

            services.AddScoped<EntityRepository<Marca>>();
            services.AddScoped<EntityService<Marca>>();
            
            services.AddScoped<EntityRepository<Modelo>>();
            services.AddScoped<EntityService<Modelo>>();

            services.AddScoped<EntityRepository<Usuario>>();
            services.AddScoped<EntityService<Usuario>>();
            
            services.AddScoped<EntityRepository<Veiculo>>();
            services.AddScoped<EntityService<Veiculo>>();

            services.AddScoped<AgendamentoService>();
            services.AddScoped<EntityRepository<Agendamento>>();
            services.AddScoped<EntityRepository<Checklist>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocacaoVeiculosApi v1"));
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
