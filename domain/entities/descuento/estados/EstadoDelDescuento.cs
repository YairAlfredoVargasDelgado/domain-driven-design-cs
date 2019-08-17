namespace domain.entities.descuento.estado
{
    public abstract class EstadoDelDescuento : IEstadoDelDescuento
    {
        public Descuento Descuento { get; set; }

        public abstract void Activar();

        public abstract void Desactivar();
    }
}