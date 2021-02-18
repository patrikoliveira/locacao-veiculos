using AutoMapper;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Marca, MarcaDto>();
            CreateMap<Modelo, ModeloDto>();
            CreateMap<Veiculo, VeiculoDto>();
    
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<CreateMarcaDto, Marca>();
            CreateMap<CreateModeloDto, Modelo>();
            CreateMap<CreateVeiculoDto, Veiculo>();
            CreateMap<DevolucaoInput, Checklist>();

            CreateMap<ModeloDto, Modelo>();
            CreateMap<MarcaDto, Marca>();
            CreateMap<CategoriaDto, Categoria>();
        }
    }
}