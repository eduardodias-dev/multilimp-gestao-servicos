using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class AtualizarClienteModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public StatusCliente Status { get; set; }
        public DateTime DataMatricula { get; set; }

    }
}
