using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Apellido { get; private set; }
        public string Clave { get; private set; }
        public string Email { get; private set; }
        public bool Habilitado { get; private set; }
        public string Nombre { get; private set; }
        public string NombreUsuario { get; private set; }

        public Usuario()
        {
        }

        public Usuario(int id, string apellido, string clave, string email, bool habilitado, string nombre, string nombreUsuario)
        {
            SetId(id);
            SetApellido(apellido);
            SetClave(clave);
            SetEmail(email);
            SetHabilitado(habilitado);
            SetNombre(nombre);
            SetNombreUsuario(nombreUsuario);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío.");
            Apellido = apellido;
        }

        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede estar vacía.");
            Clave = clave;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");
            Email = email;
        }

        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            NombreUsuario = nombreUsuario;
        }
    }
}