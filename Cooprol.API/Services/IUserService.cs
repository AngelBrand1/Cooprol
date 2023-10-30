

using Cooprol.API.Dtos;

namespace Cooprol.API.Services;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DataUserDto> GetTokenAsync(LoginDto model);
}