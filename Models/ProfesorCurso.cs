using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Model
{
    public class ProfesorCurso
    {
        private string _cargo = string.Empty;
        private int _cursoId;
        private int _usuarioId;
        public int Id { get; set; }
        public string Cargo
        {
            get => _cargo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El cargo no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El cargo no puede superar los 50 caracteres.");
                _cargo = value;
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
                    throw new ArgumentException("El ID del profesor debe ser un número positivo.");
                _usuarioId = value;
            }
        }
        public Curso Curso { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public ProfesorCurso()
        {
        }
        public ProfesorCurso(int id, string cargo, int cursoId, int usuarioId)
        {
            Id = id;
            Cargo = cargo;
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }
    }
}