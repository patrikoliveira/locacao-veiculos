using System;

namespace LocacaoVeiculosApi.Infrastructure.PdfService
{
    public class GeraPdf : IGeraPdf
    {
        public string Build(string path, string html)
        {
            var pathPDF = "/Contrato.pdf";
            try
            {
                pathPDF = $"/ContratoAluguel/ContratoAluguel-{DateTime.Now:dd-mm-yyyy}.pdf";
                var renderer = new IronPdf.HtmlToPdf();
                renderer.RenderHtmlAsPdf(html).SaveAs($"{path}/wwwroot{pathPDF}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return pathPDF;
        }
    }
}