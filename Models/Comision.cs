using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comision
    {
        private string _nombre = string.Empty;
        private int _anioEspecialidad;
        private int _planId;

        public int Id { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
                _nombre = value;
            }
        }

        public int AnioEspecialidad
        {
            get => _anioEspecialidad;
            set
            {
                if (value < 1 || value > 3000)
                    throw new ArgumentException("El año de especialidad debe estar entre 1 y 3000");
                _anioEspecialidad = value;
            }
        }

        public int PlanId
        {
            get => _planId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del plan debe ser un número positivo.");
                _planId = value;
            }
        }

        public Plan Plan { get; set; } = null!;

        public Comision()
        {
        }

        public Comision(int id, string nombre, int anioEspecialidad, int planId)
        {
            Id = id;
            Nombre = nombre;
            AnioEspecialidad = anioEspecialidad;
            PlanId = planId;
        }
    }
}