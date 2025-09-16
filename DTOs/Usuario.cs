using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Apellido { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Habilitado { get; set; }    
        public string Privilegio { get; set; } = "Usuario"; // Valor por defecto "Usuario"
        public string Nombre { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
    }
}
