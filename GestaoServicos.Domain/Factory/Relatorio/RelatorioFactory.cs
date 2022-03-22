using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Factory.Relatorio
{
    //Abstract Factory
    public abstract class RelatorioFactory
    {
        public abstract string GerarHtmlRelatorio();
    }
}
