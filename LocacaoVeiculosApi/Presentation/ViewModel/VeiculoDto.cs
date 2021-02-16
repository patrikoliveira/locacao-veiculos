namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class VeiculoDto
    {
        public int Id { get; set; }
        
        public string Placa { get; set; }
        
        public ModeloDto Modelo { get; set; }
        
        public MarcaDto Marca { get; set; }
        
        public CategoriaDto Categoria { get; set; }
        
        public string Combustivel { get; set; }

        public float ValorHora { get; set; }
        
        public int CapacidadePortaMalas { get; set; }
        
        public int CapacidadeTanque { get; set; }
    }
}