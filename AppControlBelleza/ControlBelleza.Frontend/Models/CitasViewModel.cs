using ControlBelleza.Frontend.Models;
using System.ComponentModel.DataAnnotations;

namespace ControlBelleza.Frontend.Models
{
    public class CitasViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }
        public int ClienteId { get; set; }

        
    }
}


