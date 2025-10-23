namespace Domain.Model
{
    public class Alumno : Persona
    {
        private int _legajo;

        public int Legajo
        {
            get => _legajo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El legajo debe ser un número positivo.");
                _legajo = value;
            }
        }

        public Alumno(int id)
        {
            Id = id;
        }

        public Alumno(int id, string nombre, string apellido, int dni, DateTime fechaNacimiento, int legajo)
            : base(id, nombre, apellido, dni, fechaNacimiento)
        {
            Legajo = legajo;
        }
    }
}