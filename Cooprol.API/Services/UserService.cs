using Cooprol.API.Helpers;
using Cooprol.Data;
using Cooprol.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
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
}