namespace Domain.Model
{
    public class Plan
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}