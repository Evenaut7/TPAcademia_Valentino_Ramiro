using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public int MateriaId { get; set; }
        public int ComisionId { get; set; }
    }
}
