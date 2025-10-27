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
        public string Clave { get; set; } = string.Empty; // Aquí se almacena el hash
        public string Salt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public string Privilegio { get; set; } = "Usuario"; // Valor por defecto "Usuario"
        public int PersonaId { get; set; } // Clave foránea a Persona
        public Persona? Persona { get; set; } = null!; // Propiedad de navegación a Persona
        public int? PlanId { get; set; } 
        public Plan? Plan { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string nombreUsuario, string clave, string salt, string email, bool habilitado, string privilegio, int personaId, int? planId)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            SetClave(clave);
            Salt = salt;
            Email = email;
            Habilitado = habilitado;
            Privilegio = privilegio;
            PersonaId = personaId;
            PlanId = planId;
        }

        // Método para establecer la clave (hasheada)
        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser vacía.");
            Salt = GenerateSalt();
            Clave = HashPassword(clave, Salt);
        }

        public bool ValidarClave(string clave)
        {
            var hash = HashPassword(clave, Salt);
            return Clave == hash;
        }
        private string GenerateSalt()
        {
            // Implementación para generar un salt
            return Guid.NewGuid().ToString();
        }

        private string HashPassword(string password, string salt)
        {
            // Implementación para hashear la contraseña con el salt
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var combinedPassword = password + salt;
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}