using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astech_DTO.DTO
{
    public class AparelhoDTO
    {
        public int ID { get; set; }
        public string? TipoAparelho { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? NumeroSerie { get; set; }
        public string? IMEI { get; set; }
        public bool EstadoGarantia { get; set; }
        public string? OutrasEspecificacoes { get; set; }
        public int UsuarioID { get; set; }
    }
}
