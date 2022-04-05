using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoServicos.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public StatusCliente Status { get; set; }
        public DateTime DataMatricula { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
    }
}
