using Application.DTOs.Users;
using FluentValidation;

namespace Presentation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El Email no puede ser vacio.")
                .EmailAddress().WithMessage("El Email debe tener un formato valido. ej: user@email.com.");
            
            RuleFor(x => x.IdRol).NotEmpty().WithMessage("El Rol no puede ser vacio.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña no puede ser vacio.");
        }
    }
}
