namespace domain.entities.descuento.estado
{
    public sealed class DescuentoInactivo : EstadoDelDescuento
    {


        public override void Activar()
        {
            Descuento.CambiarEstado(new DescuentoActivo());
        }

        public override void Desactivar()
        {
            throw new System.NotImplementedException();
        }
    }
}