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
        public ICollection<CriarEnderecoModel> Enderecos { get; set; }
        public ICollection<CriarTelefoneModel> Telefones { get; set; }
    }
}
