namespace Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static readonly List<Plan> Lista = new();

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