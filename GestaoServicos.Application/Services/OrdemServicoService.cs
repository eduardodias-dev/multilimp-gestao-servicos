using AutoMapper;
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
            var ordemServico = _mapper.Map<OrdemServico>(ordemServicoModel);

            _ordemServicoRepository.Add(ordemServico);
            _ordemServicoRepository.Commit();
        }

        public async Task<byte[]> GerarRelatorioOrdemServico(int idOrdemServico)
        {
            var ordemServico = await _ordemServicoRepository.Get(idOrdemServico);

            var file = _relatorioService.GerarPDF(new OrdemServicoRelatorioFactory(new OrdemServicoRelatorioModel { OrdemServico = ordemServico }));

            return file;
        }

        public IEnumerable<VisualizarOrdemServicoModel> ListarOrdemServico(FiltroOrdemServicoModel filtro)
        {
            var listOrdemServico = _mapper.Map<List<VisualizarOrdemServicoModel>>(_ordemServicoRepository.GetAll("Cliente"));

            return listOrdemServico;
        }
    }
}
