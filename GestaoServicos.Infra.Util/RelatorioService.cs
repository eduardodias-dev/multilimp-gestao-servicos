using DinkToPdf;
using DinkToPdf.Contracts;
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

        public byte[] GerarPDF()
        {
            string path = @"C:\temp\PDFCreator\Test_Report.pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = path
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GerarStringHTML(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Folha [page]/[toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Relatório Ordem Missão" }
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

        private string GerarStringHTML()
        {
            StringBuilder linhasServico = new StringBuilder();
            for(int i = 0; i <= 9; i++)
            {
                linhasServico.Append(@"<tr>
                                <td >08:17</td>
                                <td >01</td>
                                <td >08:40</td>
                                <td >09:13</td>
                                <td>
                                    <table class=\""table-left\"">
                                        <tr style=\""border: 0 !important;\"">
                                            <td><b>Sup.</b></td>
                                            <td><b>1916084</b></td>
                                            <td><b>BRINKS 137 CURITIBA R DR PAPHILO D ASSUMPCAO. 20102, PAROLIN - CURITIBA</b></td>
                                            <td>Bolsa: <b>c08:00/20:00</b></td>
                                            <td><b>BRD AG 5750 AV URB CURITIBA AV LUIZ XAVIER, 11, CENTRO - CURITIBA</b></td>
                                        </tr>
                                    </table>
                                </td>    
                                <td style=\""border: 0 !important;\"">3</td>
                                <td style=\""border: 0 !important;\""></td>
                                <td style=\""border: 0 !important;\"">R$ 551.395,11</td>
                            </tr>");
            }

            return @"<!DOCTYPE html>
                    <html lang=\""en\"">
                    <head>
                        <meta charset=\""UTF-8\"">
                        <meta http-equiv=\""X-UA-Compatible\"" content=\""IE=edge\"">
                        <meta name=\""viewport\"" content=\""width=device-width, initial-scale=1.0\"">
                        <title>Document</title>
                    </head>
                    <body>
                        <table style=\""text-align:left;border:0;\"">
                            <tr>
                                <td colspan=\""3\""><h4>Ordem de Missão - Rota: 017</h5></td>
                                <td><b>Data:</b> 13/03/2020 | sexta-feira </td>
                            </tr>
                            <tr>
                                <td><b>Carro:</b>845</td>
                                <td><b>Motorista:</b> R Guilherme90626</td>
                                <td><b>CHG:</b> RONILSON 90670 </td>
                                <td><b>VCF1:</b> CLAYTON A 90224</td>
                                <td><b>VCF2:</b> WANDERS 90767</td>
                            </tr>
                            <tr>
                                <table>
                                    <tr>
                                        <td><b>KM SAÍDA</b></td>
                                        <td>:_______</td>
                                        <td><b>HORA DE INÍCIO</b></td>
                                        <td>:_______</td>
                                        <td><b>INTERVALO</b></td>
                                        <td>:_______ÀS_______</td>
                                    </tr>
                                    <tr>
                                        <td><b>KM CHEGADA</b></td>
                                        <td>:_______</td>
                                        <td><b>HORA DE TÉRMINO</b></td>
                                        <td>:_______</td>
                                        <td><b>CONTROLADOR INÍCIO</b></td>
                                        <td>:________________</td>
                                    </tr>
                                    <tr>
                                        <td><b>TOTAL</b></td>
                                        <td>:_______</td>
                                        <td><b>TOTAL DE HORAS</b></td>
                                        <td>:_______</td>
                                        <td><b>CONTROLADOR TÉRMINO</b></td>
                                        <td>:________________</td>
                                    </tr>
                                </table>
                            </tr>
                        </table>
                        <table style=\""margin-top:10px;\"">
                            <tr>
                                <th>Hora Ini/Fim</th>
                                <th>Sq.</th>
                                <th>Hora Chegada</th>
                                <th>Hora Saída</th>
                                <th>
                                    <table style=\""text-align:left;border:0;\"">
                                        <th>Serv.</th>
                                        <th>Reduzido</th>
                                        <th>Origem</th>
                                        <th></th>
                                        <th>Destino</th>
                                    </table>
                                </th>    
                                <th >Qtd. GTV</th>
                                <th >Qtd. VOL</th>
                                <th >Subtotal</th>
                            </tr>
                            " + linhasServico.ToString()+@"
                        </table>
                    </body>
                    </html>";
        }
    }
}
