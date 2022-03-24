using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Factory.Relatorio;
using GestaoServicos.Domain.Models;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Application
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IRelatorioService _relatorioService;
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository, IRelatorioService relatorioService)
        {
            _ordemServicoRepository = ordemServicoRepository;
            _relatorioService = relatorioService;
        }

        public void CriarOrdemServico(CriarOrdemServicoModel ordemServicoModel)
        {
            _ordemServicoRepository.Add(CriarOrdemServicoModelParaOrdemServico(ordemServicoModel));
            _ordemServicoRepository.Commit();
        }

        public async Task<byte[]> GerarRelatorioOrdemServico(int idOrdemServico)
        {
            var ordemServico = await _ordemServicoRepository.Get(idOrdemServico);

            var file = _relatorioService.GerarPDF(new OrdemServicoRelatorioFactory(new OrdemServicoRelatorioModel { OrdemServico = ordemServico }));

            return file;
        }

        public IEnumerable<OrdemServico> ListarOrdemServico(FiltroOrdemServicoModel filtro)
        {
            return _ordemServicoRepository.GetAll("Cliente");
        }

        private OrdemServico CriarOrdemServicoModelParaOrdemServico(CriarOrdemServicoModel model)
        {
            return new OrdemServico
            {
                ClienteId = model.ClienteId,
                DataAgendamento = model.DataAgendamento,
                DataExecucao = model.DataExecucao,
                Descricao = model.Descricao,
                Observacoes = model.Observacoes,
                Status = model.Status
            };
        }
    }
}
