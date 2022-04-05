using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using System.Collections;
using System.Linq;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(GestaoServicosDbContext context) : base(context)
        {
        }

        public OrdemServico BuscarOrdemServicoDetalhada(int id)
        {
            var ordemServico = from os in _context.OrdemServicos
                               join c in _context.Clientes on os.ClienteId equals c.ClienteId
                               join t in _context.Telefones on c.ClienteId equals t.ClienteId
                               join e in _context.Enderecos on c.ClienteId equals e.ClienteId
                               select new OrdemServico
                               {
                                   Cliente = new Cliente
                                   {
                                       ClienteId = c.ClienteId,
                                       CPFCNPJ = c.CPFCNPJ,
                                       DataMatricula = c.DataMatricula,
                                       Endereco = e,
                                       Nome = c.Nome,
                                       Status = c.Status,
                                       Telefone = t
                                   },
                                   Desconto = os.Desconto,
                                   DataExecucao = os.DataExecucao,
                                   DataAgendamento = os.DataAgendamento,
                                   ClienteId = os.ClienteId,
                                   Descricao = os.Descricao,
                                   Funcionario = os.Funcionario,
                                   FuncionarioId = os.FuncionarioId,
                                   Observacoes = os.Observacoes,
                                   OrdemServicoId = os.OrdemServicoId,
                                   Status = os.Status,
                                   Valor = os.Valor,
                                   ValorTotal = os.ValorTotal

                               };

            return ordemServico.FirstOrDefault();


        }
    }
}
