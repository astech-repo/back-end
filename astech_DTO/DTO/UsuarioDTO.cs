using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astech_DTO.DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? EnderecoRua { get; set; }
        public int EnderecoNumero { get; set; }
        public string? EnderecoEstado { get; set; }
        public string? EnderecoCep { get; set; }
        public string? MeioDeContato { get; set; }
    }
}
