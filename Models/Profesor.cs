namespace Domain.Model
{
    public class Profesor : Persona
    {
        private string _cargo = string.Empty;

        public string Cargo
        {
            get => _cargo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El cargo no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El cargo no puede superar los 100 caracteres.");
                _cargo = value;
            }
        }

        public Profesor(int id, string nombre, string apellido, int dni, DateTime fechaNacimiento, string cargo)
            : base(id, nombre, apellido, dni, fechaNacimiento)
        {
            Cargo = cargo;
        }
    }
}
