using GestaoServicos.Domain.Factory.Relatorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Services
{
    public interface IRelatorioService
    {
        byte[] GerarPDF(RelatorioFactory relatorioFactory);
    }
}
