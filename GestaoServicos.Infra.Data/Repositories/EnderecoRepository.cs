using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(GestaoServicosDbContext context) : base(context)
        {
        }
    }
}
