using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControlBelleza.Frontend.Models
{
    public class Estilista
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(75)]
        public string Gmail { get; set; }
        [StringLength(25)]
        public string Telefono { get; set; }

    }


}


