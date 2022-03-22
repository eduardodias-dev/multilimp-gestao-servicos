using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.IoC
{
    public static class InjecaoDependencias
    {
        public static void RegistrarDependencias(IServiceCollection services)
        {
            RegistrarServicos(services);
            RegistrarRepositorios(services);
        }
        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        }
        private static void RegistrarRepositorios(IServiceCollection services) 
        { 
        
        }
    }
}
