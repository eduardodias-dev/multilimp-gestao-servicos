using GestaoServicos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Infra.Data.Context
{
    public class GestaoServicosDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        public GestaoServicosDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("GestaoServicosConnection"));
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
