using System.ComponentModel.DataAnnotations.Schema;
using domain.generics;

namespace domain.entities
{
    public class Cliente : Entity
    {
        public Nombre Nombre { get; set; }

        public int Edad { get; set; }

        public char Género { get; set; }

        [Column("Correo_electrónico")]
        public string CorreoElectrónico { get; set; }

        public string Cédula { get; set; }
    }
}