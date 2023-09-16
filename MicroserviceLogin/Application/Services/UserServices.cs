using Application.DTOs.Token;
using Application.DTOs.Users;
using Application.Exceptions;
using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<bool> RegisterUser(RegisterUser registerUser)
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

            return await _userCommand.RegisterUser(user) > 0;
        }

        public TokenDto Login(LoginUser login)
        {
            User user = _userQuery.GetUserByEmail(login.Email);

            if(user == null)
                throw new LoginException("El usuario no coincide.");

            string hash = user.Password;
            string pass = login.Password;
            bool isCorrect = BCrypt.Net.BCrypt.Verify(pass,hash);

            if(!isCorrect)
                throw new LoginException("Contraseña incorrecta.");

            return GenerateToken(user);
        }


        public TokenDto GenerateToken(User user)
        {

            IConfigurationSection jwt = _configuration.GetSection("JWT");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("id" , user.Id.ToString()),
                new Claim("email" , user.Email),
                new Claim("rol" , user.Rol.Description)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.GetSection("Key").Value));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
            );
            
            return new TokenDto() {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public List<GetUser> GetAllUsers()
        {
            IEnumerable<User> users = _userQuery.GetAllUsers();

            List<GetUser> result = users.Select(u => new GetUser()
            {
                Id = u.Id,
                Email = u.Email,
                Password = u.Password,
                Rol = u.Rol.Description
            }).ToList();

            return result;
        }
    }
}
