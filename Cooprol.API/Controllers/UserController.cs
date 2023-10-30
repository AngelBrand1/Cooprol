using Cooprol.API.Controllers;
using Cooprol.API.Dtos;
using Cooprol.API.Services;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
using Cooprol.Data;
using Cooprol.Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cooprol.API.Controllers;
public class UserController: BaseApiController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }
    [HttpPost("Token")]
    public async Task<ActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        return Ok(result);
    }
}