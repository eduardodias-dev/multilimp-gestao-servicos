using GestaoServicos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class CriarClienteModel
    {
        public string Nome { get; set; }
        public StatusCliente Status { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public CriarEnderecoModel Endereco { get; set; }
        public CriarTelefoneModel Telefone { get; set; }
    }
}
