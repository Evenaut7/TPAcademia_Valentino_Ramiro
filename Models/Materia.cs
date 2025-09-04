namespace Domain.Model
{
    public class Materia
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public string HSSemanales { get; private set; }
        public string HSTotales { get; private set; }

        private int _planId;
        private Plan? _plan;

        public int PlanId
        {
            get => _plan?.Id ?? _planId;
            set => _planId = value;
        }

        public Plan? Plan
        {
            get => _plan;
            private set
            {
                _plan = value;
                if (value != null && _planId != value.Id)
                {
                    _planId = value.Id;
                }
            }
        }

        public Materia(int id, string descripcion, string hSSemanales, string hSTotales, int iDPlan)
        {
            SetId(id);
            SetDescripcion(descripcion);
            SetHSSemanales(hSSemanales);
            SetHSTotales(hSTotales);
            SetPlanId(iDPlan);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");
            Descripcion = descripcion;
        }

        public void SetHSSemanales(string hsSemanales)
        {
            if (string.IsNullOrWhiteSpace(hsSemanales))
                throw new ArgumentException("Las horas semanales no pueden estar vacías.");
            HSSemanales = hsSemanales;
        }

        public void SetHSTotales(string hsTotales)
        {
            if (string.IsNullOrWhiteSpace(hsTotales))
                throw new ArgumentException("Las horas totales no pueden estar vacías.");
            HSTotales = hsTotales;
        }

        public void SetPlanId(int planId)
        {
            if (planId <= 0)
                throw new ArgumentException("El PaisId debe ser mayor que 0.", nameof(planId));

            _planId = planId;

            if (_plan != null && _plan.Id != planId)
            {
                _plan = null; 
            }
        }

        public void SetPlan(Plan plan)
        {
            ArgumentNullException.ThrowIfNull(plan);
            _plan = plan;
            _planId = plan.Id;
        }
    }
}
