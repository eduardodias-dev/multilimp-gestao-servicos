using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class CriarOrdemServicoModel
    {
        public int ClienteId { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataExecucao { get; set; }
        public int? FuncionarioId { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
    }
}
