using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlBelleza.Domain.Entities
{
    public class DetallePago
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int MetodoPagoId { get; set; }
        public string Referencia { get; set; } // Número de transacción, etc.

        // Propiedades de navegación
        public virtual Factura Factura { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
    }
}
