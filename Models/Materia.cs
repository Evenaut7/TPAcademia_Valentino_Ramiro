namespace Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string descripcion { get; set; }
        public string HSSemanales { get; set; }
        public string HSTotales { get; set; }
        public int IDPlan { get; set; }

        public static readonly List<Materia> Lista = new();

        public static int ObtenerProximoId()
        {
            if (Lista.Count == 0) return 0;
            int max = 0;
            foreach (var item in Lista)
            {
                if (item.Id > max) max = item.Id;
            }
            return max + 1;
        }
    }
}
