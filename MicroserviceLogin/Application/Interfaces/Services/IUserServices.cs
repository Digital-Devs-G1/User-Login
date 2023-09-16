﻿using Application.DTOs.Token;
using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IUserServices
    {
        Task<bool> RegisterUser(RegisterUser user);
        TokenDto Login(LoginUser user);
        List<GetUser> GetAllUsers();
    }
}
