using Application.DTOs.Token;
using Application.DTOs.Users;
using Application.Exceptions;
using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;
        private readonly IConfiguration _configuration;
        private readonly IRolQuery _rolQuery;

        public UserServices(IUserCommand userCommand, IUserQuery userQuery, IConfiguration configuration, IRolQuery rolQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
            _configuration = configuration;
            _rolQuery = rolQuery;
        }

        public bool RegisterUser(RegisterUser registerUser)
        {
            if(_userQuery.GetUserByEmail(registerUser.Email) != null)
                throw new LoginException("El mail ya fue registrado.");

            if(!_rolQuery.ExistRol(registerUser.IdRol))
                throw new LoginException("Id rol incorrecto.");

            User user = new User()
            {
                Email = registerUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password),
                IdRol = registerUser.IdRol
            };

            return _userCommand.RegisterUser(user) > 0;
        }
    }
}
