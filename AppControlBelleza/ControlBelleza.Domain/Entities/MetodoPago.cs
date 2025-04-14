using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBelleza.Domain.Entities
{
    public class MetodoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // "Efectivo", "Tarjeta de crédito", etc.
        public bool Activo { get; set; }

        // Propiedad de navegación
        public virtual ICollection<DetallePago> DetallesPago { get; set; }
    }
}
