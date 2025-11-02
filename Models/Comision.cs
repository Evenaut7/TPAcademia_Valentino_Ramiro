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
        private string _anioEspecialidad = string.Empty;
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

        public string AnioEspecialidad
        {
            get => _anioEspecialidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El año no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El año no puede superar los 50 caracteres.");
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

        public Comision(int id, string nombre, string anioEspecialidad, int planId)
        {
            Id = id;
            Nombre = nombre;
            AnioEspecialidad = anioEspecialidad;
            PlanId = planId;
        }
    }
}