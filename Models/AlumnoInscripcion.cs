using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AlumnoInscripcion
    {
        public int Id { get; set; }
        public string Condicion { get; set; } = string.Empty;
        public int Nota { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; } = null!;
    }
}
