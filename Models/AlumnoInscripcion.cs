using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Model
{
    public class AlumnoInscripcion
    {
        private string _condicion = string.Empty;
        private int? _nota = null;
        private int _cursoId;
        private int _usuarioId;
        public int Id { get; set; }
        public string Condicion
        {
            get => _condicion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La condición no puede estar vacía.");
                var condicionesValidas = new[] { "Inscripto", "Regular", "Aprobado", "Libre" };
                if (!condicionesValidas.Contains(value))
                    throw new ArgumentException("La condición debe ser: Inscripto, Regular, Aprobado o Libre.");
                _condicion = value;
            }
        }
        public int? Nota
        {
            get => _nota;
            set
            {
                if (value.HasValue && (value < 0 || value > 10))
                    throw new ArgumentException("La nota debe estar entre 0 y 10.");
                _nota = value;
            }
        }
        public int CursoId
        {
            get => _cursoId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del curso debe ser un número positivo.");
                _cursoId = value;
            }
        }
        public int UsuarioId
        {
            get => _usuarioId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del alumno debe ser un número positivo.");
                _usuarioId = value;
            }
        }
        public Curso Curso { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public AlumnoInscripcion()
        {
        }
        public AlumnoInscripcion(int id, string condicion, int? nota, int cursoId, int usuarioId)
        {
            Id = id;
            Condicion = condicion;
            Nota = nota;
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }
    }
}