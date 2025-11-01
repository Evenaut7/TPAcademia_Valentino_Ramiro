using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProfesorCursoDTO
    {
        public string Cargo { get; set; } = string.Empty;
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
