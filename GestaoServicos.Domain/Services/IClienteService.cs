using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Domain.Services
{
    public interface IClienteService
    {
        public void CriarCliente(CriarClienteModel clienteModel);

        public IEnumerable<Cliente> ListarClientes(FiltroClienteModel filtro);

        public Task RemoverCliente(int clienteId);

        public Task AtualizarCliente(AtualizarClienteModel clienteModel);
    }
}
