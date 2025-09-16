using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comision
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AnioEspecialidad { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        public Comision() 
        {
        }

        public Comision(int id, string nombre, int anioEspecialidad, int planId) 
        {
            Id = id;
            Nombre = nombre;
            AnioEspecialidad = anioEspecialidad;
            PlanId = planId;
        }
    }
}
