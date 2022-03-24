using GestaoServicos.Domain.Models;
using GestaoServicos.Domain.Repository;
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
    public class OrdemServicoController : ControllerBase
    {
        private readonly IOrdemServicoService _ordemServicoService;
        public OrdemServicoController(IOrdemServicoService ordemServicoService)
        {
            _ordemServicoService = ordemServicoService;
        }

        [HttpGet]
        public IActionResult GetOrdemServicos()
        {
            return Ok(_ordemServicoService.ListarOrdemServico(new FiltroOrdemServicoModel()));
        }

        [HttpGet("imprimir-ordem-servico")]
        public async Task<IActionResult> ImprimirOrdemServico(int idOrdemServico)
        {
            var file = await _ordemServicoService.GerarRelatorioOrdemServico(idOrdemServico);

            return File(file, "application/octet-stream", "ordemServico.pdf");
        }

        [HttpPost]
        public IActionResult CriarOrdemServico([FromBody] CriarOrdemServicoModel model)
        {
            try
            {
                _ordemServicoService.CriarOrdemServico(model);

                return Ok("Inserido com sucesso.");

            }catch(Exception e)
            {
                return BadRequest("Exceção inesperada.");
            }
        }
    }
}
