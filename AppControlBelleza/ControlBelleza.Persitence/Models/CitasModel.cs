using System;
using System.ComponentModel.DataAnnotations;

namespace ControlBelleza.Persitence.Models
{
    public class CitasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }

        public int ClienteId { get; set; }
        
    }
}

