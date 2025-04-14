//using ControlBelleza.Frontend.Models;
using System.ComponentModel.DataAnnotations;

namespace ControlBelleza.Domain.Entities
{
    public class Citas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public  Factura Factura { get; set; }
    }
}


