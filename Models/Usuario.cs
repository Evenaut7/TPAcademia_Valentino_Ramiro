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
        public string Apellido { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public string Nombre { get; set; } = string.Empty;
       
        private string _nombreUsuario;
        public string NombreUsuario //Ejemplo de propiedad con validación
        {
            get { return _nombreUsuario; }
            set
            {
                // Lógica de validación aquí
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("MiCampo no puede ser nulo o vacío."); // Lanza una excepción si la validación falla
                }
                else
                {
                    _nombreUsuario = value; // Asigna el valor si es válido
                }
            }
        }

        public Usuario()
        {
        }

        public Usuario(int id, string apellido, string clave, string email, bool habilitado, string nombre, string nombreUsuario)
        {
            Id = id;
            Apellido = apellido;
            Clave = clave;
            Email = email;
            Habilitado = habilitado;
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
        }
    }
}