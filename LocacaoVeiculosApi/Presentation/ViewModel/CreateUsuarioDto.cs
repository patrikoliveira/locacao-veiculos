namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record CreateUsuarioDto
    {
        public string Nome { get; internal set; }
        public int Id { get; internal set; }
        public string CpfMatricula { get; internal set; }
        public Endereco Endereco { get; internal set; }
        public string TipoUsuario { get; internal set; }
    }
}