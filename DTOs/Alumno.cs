using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AlumnoDTO : PersonaDTO
    {
        public int Legajo { get; set; }        
        public UsuarioDTO Usuario { get; set; } = null!;
        public int? UsuarioId { get; set; }
    }
}
