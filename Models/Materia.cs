namespace Domain.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string HsSemanales { get; set; } = string.Empty;
        public string HsTotales { get; set; } = string.Empty;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        public Materia()
        {
        }

        public Materia(int id, string descripcion, string hsSemanales, string hsTotales, int idPlan)
        {
            Id = id;
            Descripcion = descripcion;
            HsSemanales = hsSemanales;
            HsTotales = hsTotales;
            PlanId = idPlan;
        }
    }
}
