namespace LocacaoVeiculosApi.Domain.Entities
{
    public interface ICliente
    {
        string Cpf {get;set;}
        string DataNascimento {get;set;}
        int? EnderecoId {get;set;}
        string CpfMatricula { get; set; }
    }
}