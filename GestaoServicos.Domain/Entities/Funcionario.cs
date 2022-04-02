using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public StatusFuncionario Status { get; set; }
        public Telefone Telefone { get; set; }

    }
}
