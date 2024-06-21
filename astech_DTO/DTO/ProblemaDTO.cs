using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astech_DTO.DTO
{
    public class ProblemaDTO
    {
        public int ID { get; set; }
        public string? Descricao { get; set; }
        public string? Conduta { get; set; }
        public string? Sintomas { get; set; }
        public string? Comportamento { get; set; }
        public string? ErroAlerta { get; set; }
        public int AparelhoID { get; set; }
    }
}
