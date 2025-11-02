using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ComisionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string AnioEspecialidad { get; set; } = string.Empty;
        public int PlanId{ get; set; }

    }
}
