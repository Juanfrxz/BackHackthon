using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHabita.Helpers;
using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ApiHabita.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<UserMember> _passwordHasher;
    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,
    IPasswordHasher<UserMember> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var usuario = new UserMember
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            UserMemberRoles = new List<UserMemberRole>()
        };

        usuario.Password = _passwordHasher.HashPassword(usuario, registerDto.Password!);
        
        var usuarioExiste = _unitOfWork.UserMembers
                                    .Find(u => string.Equals(u.Username, registerDto.Username, StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

        if (usuarioExiste == null)
        {
            var rolPredeterminado = _unitOfWork.UserMemberRoles
                                    .Find(u => u.Role != null && u.Role.Name == "User")
                                    .First();
            try
            {
                usuario.UserMemberRoles.Add(rolPredeterminado);
                _unitOfWork.UserMembers.Add(usuario);
                await _unitOfWork.SaveAsync();

                return $"El usuario  {registerDto.Username} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"El usuario con {registerDto.Username} ya se encuentra registrado.";
        }
    }

    public Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public Task<string> AddRoleAsync(AddRoleDto model)
    {
        throw new NotImplementedException();
    }

    public Task<DataUserDto> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
}
