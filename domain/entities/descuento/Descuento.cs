using domain.entities.descuento.estado;
using domain.generics;

namespace domain.entities.descuento
{
    public class Descuento : Entity, IEstadoDelDescuento
    {
        public EstadoDelDescuento EstadoDelDescuento { get; set; }

        public float? Porcentaje { get; set; }

        public float? Valor { get; set; }

        public void Activar()
        {
            EstadoDelDescuento.Activar();
        }

        public void Desactivar()
        {
            EstadoDelDescuento.Desactivar();
        }

        public void CambiarEstado(EstadoDelDescuento estadoDelDescuento)
        {
            EstadoDelDescuento = estadoDelDescuento;
        }
    }
}