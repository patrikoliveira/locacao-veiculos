namespace LocacaoVeiculosApi.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public float ValorHora { get; set; }
        public int CapacidadePortaMalas { get; set; }
        public int CapacidadeTanque { get; set; }
    }
}