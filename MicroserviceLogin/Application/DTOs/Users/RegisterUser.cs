using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users
{
    public class RegisterUser
    {
        //[EmailAddress(ErrorMessage = "El campo debe ser un correo valido")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
