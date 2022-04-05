using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GestaoServicosDbContext context) : base(context)
        {
        }

        public IQueryable<Cliente> BuscarClientesComDados()
        {

            return _context.Clientes.Include(c => c.Telefone).Include(c => c.Endereco);
        }
    }
}
