using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlBelleza.Domain.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagada { get; set; }
        public string Estado { get; set; } // "Pendiente", "Pagada", "Cancelada", etc.

        // Propiedades de navegación
        public virtual Citas Cita { get; set; }
        public virtual ICollection<DetallePago> DetallesPago { get; set; }
    }

}
