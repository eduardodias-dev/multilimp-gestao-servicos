using GestaoServicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Repository
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        public OrdemServico BuscarOrdemServicoDetalhada(int id);
    }
}
