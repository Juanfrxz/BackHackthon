using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ApiHabita.Helpers;
using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            Password = registerDto.Password,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        usuario.Password = _passwordHasher.HashPassword(usuario, registerDto.Password!);

        var usuarioExiste = _unitOfWork.UserMembers
                                    .Find(u => u.Username.ToLower() == registerDto.Username.ToLower())
                                    .FirstOrDefault();

        if (usuarioExiste == null)
        {
            var rolPredeterminado = _unitOfWork.Roles
                                    .Find(u => u.Name == UserAuthorization.rol_predeterminado.ToString())
                                    .First();
            try
            {
                usuario.Roles.Add(rolPredeterminado);
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

    public async Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
        DataUserDto datosUsuario = new DataUserDto();
        var usuario = await _unitOfWork.UserMembers
                    .GetByUserNameAsync(model.Username);
        if (usuario == null)
        {
            datosUsuario.EstaAutenticado = false;
            datosUsuario.Mensaje = $"No existe ningún usuario con el username {model.Username}.";
            return datosUsuario;
        }

        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
        if (resultado == PasswordVerificationResult.Success)
        {
            datosUsuario.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
            datosUsuario.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuario.Email = usuario.Email;
            datosUsuario.UserName = usuario.Username;
            datosUsuario.Roles = usuario.Roles
                                            .Select(r => r.Name)
                                            .ToList();
            return datosUsuario;
        }
        datosUsuario.EstaAutenticado = false;
        datosUsuario.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Username}.";
        return datosUsuario;
    }

    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.UserMembers
                    .GetByUserNameAsync(model.Username);

        if (usuario == null)
        {
            return $"No existe algún usuario registrado con la cuenta {model.Username}.";
        }
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);


        if (resultado == PasswordVerificationResult.Success)
        {


            var rolExiste = _unitOfWork.Roles
                                        .Find(u => u.Name.ToLower() == model.Role.ToLower())
                                        .FirstOrDefault();

            if (rolExiste != null)
            {
                var usuarioTieneRol = usuario.Roles
                                            .Any(u => u.Id == rolExiste.Id);

                if (usuarioTieneRol == false)
                {
                    usuario.Roles.Add(rolExiste);
                    _unitOfWork.UserMembers.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }

                return $"Rol {model.Role} agregado a la cuenta {model.Username} de forma exitosa.";
            }

            return $"Rol {model.Role} no encontrado.";
        }
        return $"Credenciales incorrectas para el usuario {usuario.Username}.";
    }

    public Task<DataUserDto> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
       private JwtSecurityToken CreateJwtToken(UserMember usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Name));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, usuario.Username),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                                new Claim("uid", usuario.Id.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
