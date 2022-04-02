using DinkToPdf;
using DinkToPdf.Contracts;
using GestaoServicos.Domain.Factory.Relatorio;
using GestaoServicos.Domain.Services;
using System;
using System.IO;
using System.Text;

namespace GestaoServicos.Infra.Util
{
    public class RelatorioService : IRelatorioService
    {
        private IConverter _converter;

        public RelatorioService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GerarPDF(RelatorioFactory relatorioFactory)
        {
            string path = @"C:\temp\PDFCreator\Test_Report.pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4Small,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = path
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = relatorioFactory.GerarHtmlRelatorio(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Folha [page]/[toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Multilimp Serviços Limpeza" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            using(var fileStream = File.Open(path, FileMode.Open)){
                using (MemoryStream stream = new MemoryStream())
                {
                    fileStream.CopyTo(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
