namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public string Tipo { get; set; } = string.Empty; // "Administrador", "Profesor", "Alumno"
        public string? Cargo { get; set; } = string.Empty;
        public string Legajo { get; set; } = string.Empty;
        public int PersonaId { get; set; }
        public PersonaDTO? Persona { get; set; }
        public int? PlanId { get; set; }
        public PlanDTO? Plan { get; set; }
    }
}