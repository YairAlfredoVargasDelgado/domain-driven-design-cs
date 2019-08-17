using System;

namespace domain.entities.descuento.estado
{
    public sealed class DescuentoActivo : EstadoDelDescuento
    {
        public override void Activar()
        {
            throw new System.NotImplementedException();
        }

        public override void Desactivar()
        {
            Descuento.CambiarEstado(new DescuentoInactivo());
        }
    }
}