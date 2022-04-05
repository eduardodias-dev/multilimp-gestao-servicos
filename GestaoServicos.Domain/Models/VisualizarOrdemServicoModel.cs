using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class VisualizarOrdemServicoModel
    {
        public int OrdemServicoId { get; set; }
        public int ClienteId { get; set; }
        public StatusOrdemServico Status { get; set; }
        public Cliente Cliente { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataExecucao { get; set; }
        public VisualizarTelefoneModel Telefone { get; set; }
        public VisualizarEnderecoModel Endereco { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal => Valor - Desconto;
        public string NomeCliente => $"{Cliente?.Nome}";
        public string TelefoneCompleto => $"{Telefone?.DDD} {Telefone?.Numero}"; 
        public string EnderecoCompleto => $"{Endereco?.Logradouro},{Endereco?.Numero} {Endereco?.Complemento ?? ""}, {Endereco?.Cidade}/{Endereco?.UF}"; 
    }
}
