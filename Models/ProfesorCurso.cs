using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProfesorCurso
    {
        public int Cargo { get; set; }
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int ProfesorId { get; set; }
        public Curso Curso { get; set; } = null!;
        public Profesor Profesor { get; set; } = null!;
    }
}
