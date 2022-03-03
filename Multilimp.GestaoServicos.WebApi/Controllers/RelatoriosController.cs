using GestaoServicos.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multilimp.GestaoServicos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        public IActionResult GerarPDF()
        {
            var pdf = _relatorioService.GerarPDF();
            return File(pdf, "application/pdf", "TestePdf.pdf");
        }
    }
}
