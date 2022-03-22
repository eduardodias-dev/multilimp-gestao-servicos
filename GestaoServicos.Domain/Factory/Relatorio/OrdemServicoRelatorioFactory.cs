using GestaoServicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Factory.Relatorio
{
    public class OrdemServicoRelatorioFactory : RelatorioFactory
    {
        private readonly OrdemServicoRelatorioModel _ordemServicoRelatorioModel;
        public OrdemServicoRelatorioFactory(OrdemServicoRelatorioModel model)
        {
            _ordemServicoRelatorioModel = model;
        }
        public override string GerarHtmlRelatorio()
        {
            return @"<html>
                        <body>Teste Relatório Ordem Serviço</body>
                    </html>";
        }
    }
}
