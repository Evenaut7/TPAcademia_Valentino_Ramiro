namespace Domain.Model
{
    public class Plan
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; } = null!;
    }
}