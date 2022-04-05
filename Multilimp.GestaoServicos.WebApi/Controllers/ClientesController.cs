using GestaoServicos.Domain.Models;
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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult ListarClientes([FromQuery]FiltroClienteModel model)
        {
            var clientes = _clienteService.ListarClientes(model);

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CriarCliente([FromBody] CriarClienteModel model)
        {
            try
            {
                _clienteService.CriarCliente(model);

                return Ok("Inserido com sucesso");

            }catch(Exception ex)
            {
                return BadRequest("Exceção inesperada.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCliente(int id)
        {
            try
            {
                _clienteService.RemoverCliente(id);

                return Ok("Removido com sucesso");

            }catch(Exception ex)
            {
                return BadRequest("Exceção inesperada");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditarCliente([FromBody] AtualizarClienteModel clienteModel, int id)
        {
            try
            {
                if (id != clienteModel.ClienteId) return BadRequest("Id diferente");

                _clienteService.AtualizarCliente(clienteModel);

                return Ok("Removido com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest("Exceção inesperada");
            }
        }

    }
}
