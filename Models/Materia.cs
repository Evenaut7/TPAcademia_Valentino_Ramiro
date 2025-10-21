namespace Domain.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int HsSemanales { get; set; } 
        public int HsTotales { get; set; } 

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        public Materia()
        {
        }

        public Materia(int id, string descripcion, int hsSemanales, int hsTotales, int idPlan)
        {
            Id = id;
            Descripcion = descripcion;
            HsSemanales = hsSemanales;
            HsTotales = hsTotales;
            PlanId = idPlan;
        }
    }
}
