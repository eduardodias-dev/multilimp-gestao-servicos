using AutoMapper;
using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Models;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Application
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository,
                              IEnderecoRepository enderecoRepository,
                              ITelefoneRepository telefoneRepository,
                              IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public void CriarCliente(CriarClienteModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);

            _clienteRepository.Add(cliente);
            _clienteRepository.Commit();
        }

        public IEnumerable<Cliente> ListarClientes(FiltroClienteModel filtro)
        {
            var clientes = _clienteRepository.BuscarClientesComDados();
            
            return clientes;
        }

        public async Task RemoverCliente(int clienteId)
        {
            var cliente = await _clienteRepository.Get(clienteId);

            if (cliente == null) throw new ApplicationException("Cliente não encontrado");

            var telefones = _telefoneRepository.Get(x => x.ClienteId == clienteId);
            foreach(var telefone in telefones)
            {
                _telefoneRepository.Remove(telefone);
            }

            var enderecos = _enderecoRepository.Get(x => x.ClienteId == clienteId);
            foreach (var endereco in enderecos)
            {
                _enderecoRepository.Remove(endereco);
            }

            _clienteRepository.Remove(cliente);
            _clienteRepository.Commit();
        }

        public async Task AtualizarCliente(AtualizarClienteModel clienteModel)
        {
            var cliente = await _clienteRepository.Get(clienteModel.ClienteId);

            if (cliente == null) throw new ApplicationException("Cliente não encontrado");

            cliente.DataMatricula = clienteModel.DataMatricula;
            cliente.Nome = clienteModel.Nome;
            cliente.Status = clienteModel.Status;

            _clienteRepository.Update(cliente);
            _clienteRepository.Commit();
        }

    }
}
