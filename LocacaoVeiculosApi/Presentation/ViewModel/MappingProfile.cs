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
            CreateMap<Usuario, OperadorDto>()
                .ForMember(u => u.Matricula, opt => opt.MapFrom(m => m.CpfMatricula));
            CreateMap<Usuario, ClienteDto>()
                .ForMember(u => u.Cpf, opt => opt.MapFrom(m => m.CpfMatricula));
            CreateMap<Veiculo, VeiculoDto>();
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<Agendamento, AgendamentoDto>();
            CreateMap<UsuarioLogin, ClienteLogin>()
                .ForMember(u => u.Cpf, opt => opt.MapFrom(m => m.CpfMatricula));
            CreateMap<UsuarioLogin, OperadorLogin>()
                .ForMember(u => u.Matricula, opt => opt.MapFrom(m => m.CpfMatricula));

            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<CreateMarcaDto, Marca>();
            CreateMap<CreateModeloDto, Modelo>();
            CreateMap<CreateVeiculoDto, Veiculo>();
            CreateMap<DevolucaoInput, Checklist>();
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<CreateOperadorDto, Operador>();
            CreateMap<CreateOperadorDto, Usuario>();
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<ModeloDto, Modelo>();
            CreateMap<MarcaDto, Marca>();
            CreateMap<ClienteLogin, Usuario>();
            CreateMap<OperadorLogin, Usuario>();
            CreateMap<ClienteLogin, UsuarioLogin>();
            CreateMap<OperadorLogin, UsuarioLogin>();
        }
    }
}