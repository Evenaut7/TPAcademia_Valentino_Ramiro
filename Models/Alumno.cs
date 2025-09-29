using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Alumno : Persona
    {
        public Alumno(int id, string legajo, int usuarioId)
        {
            Id = id;
            Legajo = legajo;
            UsuarioId = usuarioId;
        }

        public Alumno(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, string legajo, int usuarioId) : base (id, nombre, apellido, dni, fechaNacimiento)
        {

        }
        public string Legajo { get; set; } = string.Empty;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
