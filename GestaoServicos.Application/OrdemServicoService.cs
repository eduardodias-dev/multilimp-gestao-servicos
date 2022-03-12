using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Models;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Application
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoRepository = ordemServicoRepository;

        }

        public void CriarOrdemServico(OrdemServico ordemServico)
        {
            _ordemServicoRepository.Add(ordemServico);   
        }

        public IEnumerable<OrdemServico> ListarOrdemServico(FiltroOrdemServicoModel filtro)
        {
            return _ordemServicoRepository.GetAll();
        }
    }
}
