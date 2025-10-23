namespace Domain.Model
{
    public class Materia
    {
        private int _id;
        private string _descripcion = string.Empty;
        private int _hsSemanales;
        private int _hsTotales;
        private int _planId;
        private Plan _plan = null!;

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El ID no puede ser negativo.");
                _id = value;
            }
        }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La descripción no puede estar vacía.");
                if (value.Length > 100)
                    throw new ArgumentException("La descripción no puede tener más de 100 caracteres.");
                _descripcion = value;
            }
        }

        public int HsSemanales
        {
            get => _hsSemanales;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las horas semanales deben ser mayores que cero.");
                if (value > 30)
                    throw new ArgumentException("Las horas semanales no pueden superar las 30.");
                _hsSemanales = value;
            }
        }

        public int HsTotales
        {
            get => _hsTotales;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las horas totales deben ser mayores que cero.");
                if (value < _hsSemanales)
                    throw new ArgumentException("Las horas totales no pueden ser menores que las semanales.");
                _hsTotales = value;
            }
        }

        public int PlanId
        {
            get => _planId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del plan debe ser un número positivo.");
                _planId = value;
            }
        }

        public Plan Plan
        {
            get => _plan;
            set => _plan = value ?? throw new ArgumentNullException(nameof(Plan), "El plan no puede ser nulo.");
        }

        public Materia() { }

        public Materia(int id, string descripcion, int hsSemanales, int hsTotales, int idPlan)
        {
            Id = id;
            Descripcion = descripcion;
            HsSemanales = hsSemanales;
            HsTotales = hsTotales;
            PlanId = idPlan;
        }
    }
}
