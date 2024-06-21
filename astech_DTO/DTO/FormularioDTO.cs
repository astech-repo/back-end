using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astech_DTO.DTO
{
    public class FormularioDTO
    {
        public UsuarioDTO? Usuario { get; set; }
        public AparelhoDTO? Aparelho { get; set; }
        public ProblemaDTO? Problema { get; set; }
    }
}
