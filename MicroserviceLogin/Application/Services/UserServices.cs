using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Users;
using Application.Interfaces.Commands;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserCommand _userCommand;
        public UserServices(IUserCommand userCommand)
        {
            _userCommand = userCommand;
        }

        public void AuthenticateUser()
        {




        }

        public string RegisterUser(RegisterUser registerUser)
        {

            // register user --> validate rol, encript pass
            User user = new User() { 
                Email = registerUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password)
            };

            bool register = _userCommand.RegisterUser(user) > 0;

            return register ? "Usuario registrado" : "Usuario no registrado";
        }
    }
}
