using ControlBelleza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBelleza.infrastructure.Models
{
    class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Nickname { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        public ICollection<Citas> Citas { get; set; }
    }
}
