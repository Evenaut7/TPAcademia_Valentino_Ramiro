namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Privilegio { get; set; } = "Usuario";
        public bool Habilitado { get; set; }

        public int PersonaId { get; set; }
        public PersonaDTO? Persona { get; set; }
    }
}
