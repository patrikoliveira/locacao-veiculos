using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Infrastructure.Database;
using LocacaoVeiculosApi.Presentation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class VeiculoRepository : BaseRepository
    {
        public VeiculoRepository(EntityContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VeiculoOutputRepository>> GetVeiculosDisponiveisAsync()
        {
            var query = (
                from veiculos in _context.Veiculos
                join agendamentos in _context.Agendamentos on veiculos.Id equals agendamentos.VeiculoId
                join modelos in _context.Modelos on veiculos.ModeloId equals modelos.Id 
                join marcas in _context.Marcas on veiculos.MarcaId equals marcas.Id
                join categorias in _context.Categorias on veiculos.CategoriaId equals categorias.Id
                where agendamentos.DataHoraEntregaRealizada == null
                select new VeiculoOutputRepository
                {
                    id = veiculos.Id,
                    placa = veiculos.Placa,
                    modelo = modelos.Nome,
                    marca = marcas.Nome,
                    categoria = categorias.Nome,
                    valorHora = veiculos.ValorHora,
                    capacidadePortaMalas = veiculos.CapacidadePortaMalas,
                    capacidadeTanque = veiculos.CapacidadeTanque
                }
            ).Distinct();

            return await query.ToListAsync();
        }
    }
}