using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Entities
{
    public class OrdemServico
    {
        public int OrdemServicoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataExecucao { get; set; }
        public Funcionario Funcionario { get; set; }
        public int? FuncionarioId { get;set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
        public int DiasGarantia => 15;
        
    }
}
