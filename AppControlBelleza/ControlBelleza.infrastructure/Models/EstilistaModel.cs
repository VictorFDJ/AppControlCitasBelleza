using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBelleza.Persitence.Models
{
    class EstilistaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(75)]
        public string Gmail { get; set; }

        [StringLength(25)]
        public string Telefono { get; set; }
    }
}
