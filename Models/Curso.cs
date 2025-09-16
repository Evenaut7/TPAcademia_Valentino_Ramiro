using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Curso
    {
        public int Id { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public int MateriaId { get; set; }
        public int ComisionId { get; set; }
        public Materia Materia { get; set; } = null!;
        public Comision Comision { get; set; } = null!;

        public Curso(){
        }
        public Curso(int id, int anioCalendario, int cupo, int materiaId, int comisionId){
            Id = id;
            AnioCalendario = anioCalendario;
            Cupo = cupo;
            MateriaId = materiaId;
            ComisionId = comisionId;
        }



    }
}
