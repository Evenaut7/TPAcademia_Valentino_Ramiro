using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AlumnoInscripcionDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public string Condicion { get; set; } = string.Empty;
        public int? Nota { get; set; } = null;
    }
}
