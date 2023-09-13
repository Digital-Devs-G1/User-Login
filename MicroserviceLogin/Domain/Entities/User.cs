using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "el campo ingresado debe ser un email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(70)]
        public string Password { get; set; }

        //[ForeignKey("Rol")]
        //public int IdRol { get; set; }
        //public Rol Rol { get; set; }
    }
}
