using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class FiltroOrdemServicoModel
    {
        public int ClienteId { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAgendamentoDe { get; set; }
        public DateTime DataAgendamentoAte { get; set; }
        public DateTime DataExecucaoDe { get; set; }
        public DateTime DataExecucaoAte { get; set; }
    }
}
