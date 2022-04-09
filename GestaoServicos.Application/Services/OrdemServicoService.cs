using AutoMapper;
using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Enums;
using GestaoServicos.Domain.Factory.Relatorio;
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
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IRelatorioService _relatorioService;
        private readonly IMapper _mapper;
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository, 
                                    IRelatorioService relatorioService,
                                    IMapper mapper)
        {
            _ordemServicoRepository = ordemServicoRepository;
            _relatorioService = relatorioService;
            _mapper = mapper;
        }

        public void CriarOrdemServico(CriarOrdemServicoModel ordemServicoModel)
        {

            if (ordemServicoModel.Status == StatusOrdemServico.Executado && (!ordemServicoModel.DataExecucao.HasValue))
                throw new ApplicationException("Data de execução inválida");

            if (ordemServicoModel.DataAgendamento > ordemServicoModel.DataExecucao)
                throw new ApplicationException("Data de execução não pode ser maior que a data de Agendamento");

            var ordemServico = _mapper.Map<OrdemServico>(ordemServicoModel);


            _ordemServicoRepository.Add(ordemServico);
            _ordemServicoRepository.Commit();
        }

        public async Task<byte[]> GerarRelatorioOrdemServico(int idOrdemServico)
        {
            var ordemServico = _ordemServicoRepository.BuscarOrdemServicoDetalhada(idOrdemServico);

            var file = _relatorioService.GerarPDF(new OrdemServicoRelatorioFactory(
                                                            new OrdemServicoRelatorioModel { OrdemServico = _mapper.Map<VisualizarOrdemServicoModel>(ordemServico) }));

            return file;
        }

        public IEnumerable<VisualizarOrdemServicoModel> ListarOrdemServico(FiltroOrdemServicoModel filtro)
        {
            var listOrdemServico = _mapper.Map<List<VisualizarOrdemServicoModel>>(_ordemServicoRepository.BuscarOrdensServicoDetalhadas());

            return listOrdemServico;
        }
    }
}
