namespace LocacaoVeiculosApi.Infrastructure.PdfService
{
    public interface IGeraPdf
    {
        string Build(string path, string body);
    }
}