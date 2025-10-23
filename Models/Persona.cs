using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Persona
    {
        private string _nombre = string.Empty;
        private string _apellido = string.Empty;
        private int _dni;
        private DateTime _fechaNacimiento;

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

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El apellido no puede superar los 50 caracteres.");
                _apellido = value;
            }
        }

        public int Dni
        {
            get => _dni;
            set
            {
                if (value < 1 || value > 99999999)
                    throw new ArgumentException("El DNI debe estar entre 1 y 99.999.999.");
                _dni = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
                if (value < new DateTime(1900, 1, 1))
                    throw new ArgumentException("La fecha de nacimiento no puede ser anterior a 1900.");
                _fechaNacimiento = value;
            }
        }

        public Persona() { }

        public Persona(int id, string nombre, string apellido, int dni, DateTime fechaNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
        }
    }
}