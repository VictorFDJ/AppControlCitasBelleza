using System;
using System.ComponentModel.DataAnnotations;

namespace ControlBelleza.Persitence.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Lastname { get; set; }

        [StringLength(50, ErrorMessage = "El nickname no puede tener más de 50 caracteres.")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número de teléfono no puede tener más de 15 caracteres.")]
        public string PhoneNumber { get; set; }
    }
}

