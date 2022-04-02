using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Domain.Services
{
    public interface IOrdemServicoService
    {
        public void CriarOrdemServico(CriarOrdemServicoModel ordemServicoModel);

        public IEnumerable<VisualizarOrdemServicoModel> ListarOrdemServico(FiltroOrdemServicoModel filtro);

        public Task<byte[]> GerarRelatorioOrdemServico(int idOrdemServico);
    }
}
