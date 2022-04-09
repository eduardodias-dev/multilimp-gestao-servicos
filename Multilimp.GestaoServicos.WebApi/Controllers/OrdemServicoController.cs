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
            try
            {
                return Ok(_ordemServicoService.ListarOrdemServico(new FiltroOrdemServicoModel()));
            }
            catch (Exception ex)
            {
                return BadRequest("Exceção inesperada. " + ex.Message);
            }
            
        }

        [HttpGet("imprimir-ordem-servico/{idOrdemServico}")]
        public async Task<IActionResult> ImprimirOrdemServico(int idOrdemServico)
        {
            try
            {
                var file = await _ordemServicoService.GerarRelatorioOrdemServico(idOrdemServico);

                return File(file, "application/pdf", $"ordemservico_{idOrdemServico}.pdf");

            }
            catch(Exception ex)
            {
                return BadRequest("Exceção inesperada. " + ex.Message);
            }
            
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
                return BadRequest("Exceção inesperada. " + e.Message);
            }
        }
    }
}
