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
        public void CriarOrdemServico(OrdemServico ordemServico);

        public IEnumerable<OrdemServico> ListarOrdemServico(FiltroOrdemServicoModel filtro);

        public Task<byte[]> GerarRelatorioOrdemServico(int idOrdemServico);
    }
}
