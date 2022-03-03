using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public Cliente Cliente { get; set; }
    }
}
