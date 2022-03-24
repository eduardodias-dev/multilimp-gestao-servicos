using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(GestaoServicosDbContext context) : base(context)
        {
        }
    }
}
