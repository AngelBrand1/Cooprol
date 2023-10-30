using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cooprol.API.Dtos;
using Cooprol.API.Helpers;
using Cooprol.Data;
using Cooprol.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Cooprol.API.Services;
public class UserService: IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;


    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,
    IPasswordHasher<User>  passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
        
        DataUserDto dataUser = new DataUserDto();
        try
        {
            var userExiste = await _unitOfWork.UserRepository.GetAllAsync(x => x.UserName == model.UserName,null,"Roles");
            if(userExiste.FirstOrDefault<User>() == null)
            {
                dataUser.isAutenticate = false;
                dataUser.Message = $"User or Password incorrect";
                return dataUser;
            }
            var user = userExiste.First();
            var res = _passwordHasher.VerifyHashedPassword(user,user.Password,model.Password);
            if(res == PasswordVerificationResult.Success)
            {
                dataUser.isAutenticate = true;
                JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
                dataUser.Token = new JwtSecurityTokenHandler()
                                .WriteToken(jwtSecurityToken);
                dataUser.Email = user.Email;
                dataUser.UserName = user.UserName;
                dataUser.Roles = user.Roles
                                        .Select(u => u.Desciption)
                                        .ToList();
                return dataUser;
            }
            dataUser.isAutenticate = false;
            dataUser.Message = "User or Password incorrect";
            return dataUser;
        }
        catch(Exception ex)
        {
            dataUser.isAutenticate = false;
            dataUser.Message = ex.Message;
            return dataUser;
        }
    }
    private JwtSecurityToken CreateJwtToken(User user)
    {
        var roles = user.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Desciption));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                                new Claim("uid", user.Id.ToString())
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
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User
        {
            Name = registerDto.Name,
            NumberCc = registerDto.NumberCc,
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            Password = registerDto.Password
        };

        user.Password = _passwordHasher.HashPassword(user, registerDto.Password);

        var userExiste = await _unitOfWork.UserRepository.GetAllAsync(x => x.UserName == registerDto.UserName);

        

        if (userExiste.FirstOrDefault() == null)
        {
            var rolPredeterminado = await _unitOfWork.RoleRepository
                                        .GetAllAsync(x => x.Desciption == Autorization.DefaultRole.ToString());
            try
            {
                
                user.Roles.Add(rolPredeterminado.First());
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return $"El User  {registerDto.UserName } ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"El User con {registerDto.UserName } ya se encuentra registrado.";
        }
    }
}