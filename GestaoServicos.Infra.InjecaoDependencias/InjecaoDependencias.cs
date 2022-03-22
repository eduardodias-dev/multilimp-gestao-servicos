﻿using DinkToPdf;
using DinkToPdf.Contracts;
using GestaoServicos.Application;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Domain.Services;
using GestaoServicos.Infra.Data.Context;
using GestaoServicos.Infra.Data.Repositories;
using GestaoServicos.Infra.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.InjecaoDependencias
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
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddDbContext<GestaoServicosDbContext>();

        }
        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
        }
    }
}