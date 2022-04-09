using GestaoServicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoServicos.Domain.Repository
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        public OrdemServico BuscarOrdemServicoDetalhada(int id);
        IQueryable<OrdemServico> BuscarOrdensServicoDetalhadas();
    }

}
