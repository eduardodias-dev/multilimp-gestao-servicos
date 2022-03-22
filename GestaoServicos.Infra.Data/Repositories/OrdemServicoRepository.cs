using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(GestaoServicosDbContext context) : base(context)
        {
        }
    }
}
