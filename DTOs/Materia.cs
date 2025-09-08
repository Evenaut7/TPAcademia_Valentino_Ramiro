namespace DTOs
{
    public class MateriaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string HsSemanales { get; set; } = string.Empty;
        public string HsTotales { get; set; } = string.Empty;
        public int PlanId { get; set; }

    }
}
