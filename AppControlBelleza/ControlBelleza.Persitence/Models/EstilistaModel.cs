using System.ComponentModel.DataAnnotations;

namespace ControlBelleza.Persitence.Models
{
    public class EstilistaModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Apellido { get; set; }

        [StringLength(75, ErrorMessage = "El Gmail no puede tener más de 75 caracteres.")]
        public string Gmail { get; set; }

        [StringLength(25, ErrorMessage = "El número de teléfono no puede tener más de 25 caracteres.")]
        public string Telefono { get; set; }
    }
}
