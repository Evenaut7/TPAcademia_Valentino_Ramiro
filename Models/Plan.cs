namespace Domain.Model
{
    public class Plan
    {
        private string _descripcion = string.Empty;
        private int _especialidadId;

        public int Id { get; set; }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La descripción no puede estar vacía.");
                if (value.Length > 100)
                    throw new ArgumentException("La descripción no puede superar los 100 caracteres.");
                _descripcion = value;
            }
        }

        public int EspecialidadId
        {
            get => _especialidadId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID de especialidad debe ser un número positivo.");
                _especialidadId = value;
            }
        }

        public Especialidad Especialidad { get; set; } = null!;
    }
}