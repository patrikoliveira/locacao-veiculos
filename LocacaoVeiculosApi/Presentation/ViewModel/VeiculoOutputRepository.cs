namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class VeiculoOutputRepository
    {
        public int id { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
        // public string combustivel { get; set; }
        public float valorHora { get; set; }
        public int capacidadePortaMalas { get; set; }
        public int capacidadeTanque { get; set; }
    }
}