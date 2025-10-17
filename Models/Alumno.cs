using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Alumno : Persona
    {
        public Alumno(int id)
        {
            Id = id;
        }

        public Alumno(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, string legajo)
            : base(id, nombre, apellido, dni, fechaNacimiento)
        {
            Legajo = legajo;
        }

        public string Legajo { get; set; } = string.Empty;
    }
}
