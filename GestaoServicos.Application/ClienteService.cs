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

        public ClienteService(IClienteRepository clienteRepository,
                              IEnderecoRepository enderecoRepository,
                              ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
            _enderecoRepository = enderecoRepository;
        }

        public void CriarCliente(CriarClienteModel clienteModel)
        {
            var endereco = CriarClienteModelParaCliente(clienteModel);

            _clienteRepository.Add(endereco);
            _clienteRepository.Commit();
        }

        public IEnumerable<Cliente> ListarClientes(FiltroClienteModel filtro)
        {
            var clientes = _clienteRepository.GetAll("Telefones");

            foreach(var cliente in clientes)
            {
                cliente.Enderecos = _enderecoRepository.Get(x => x.ClienteId == cliente.ClienteId).ToList();
                cliente.Telefones = _telefoneRepository.Get(x => x.ClienteId == cliente.ClienteId).ToList();
            }

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

        private Cliente CriarClienteModelParaCliente(CriarClienteModel model)
        {
            return new Cliente
            {
                DataMatricula = model.DataMatricula,
                Nome = model.Nome,
                Status = model.Status,
                Enderecos = model.Enderecos?.Select(CriarEnderecoModelParaEndereco).ToList(),
                Telefones = model.Telefones?.Select(CriarTelefoneModelParaTelefone).ToList()
            };
        }

        private Endereco CriarEnderecoModelParaEndereco(CriarEnderecoModel model)
        {
            return new Endereco
            {
                Cidade = model.Cidade,
                ClienteId = model.ClienteId,
                Complemento = model.Complemento,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                UF = model.UF
            };
        }

        private Telefone CriarTelefoneModelParaTelefone(CriarTelefoneModel model)
        {
            return new Telefone
            {
                ClienteId = model.ClienteId,
                DDD = model.DDD,
                Numero = model.Numero,
                
            };
        }
    }
}
