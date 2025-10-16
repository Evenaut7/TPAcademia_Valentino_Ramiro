using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Profesor : Persona
    {
        public Profesor(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, string cargo)
            : base(id, nombre, apellido, dni, fechaNacimiento)
        {
            Cargo = cargo;
        }
        public string Cargo { get; set; } = string.Empty;

    }
}
