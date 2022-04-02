using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoServicos.Domain.Models
{
    public class VisualizarTelefoneModel
    {
        public int TelefoneId { get; set; }
        public int ClienteId { get; set; }
        public short DDD { get; set; }
        public int Numero { get; set; }
    }
}
