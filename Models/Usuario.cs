using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public string Privilegio { get; set; } = "Usuario"; // Valor por defecto "Usuario"

        public int PersonaId { get; set; } // Clave foránea a Persona
        public Persona Persona { get; set; } = null!; // Propiedad de navegación a Persona

        public Usuario()
        {
        }

        public Usuario(int id, string nombreUsuario, string clave, string email, bool habilitado, string privilegio, int personaId)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Email = email;
            Habilitado = habilitado;
            Privilegio = privilegio;
            PersonaId = personaId;
        }
    }
}