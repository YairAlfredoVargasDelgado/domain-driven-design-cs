using System;

namespace domain.entities.descuento.estados
{
    public class DescuentoPausado
    {
        public DateTime Fecha { get; set; }
        public DescuentoPausado(DateTime fecha)
        {
            this.Fecha = fecha;
        }
    }
}