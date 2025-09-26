using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProfesorDTO : PersonaDTO
    {
        public string Cargo { get; set; } = string.Empty;
        // Otros campos específicos de Profesor
        public UsuarioDTO Usuario { get; set; } = null!;
        public int UsuarioId { get; set; }
    }
}
