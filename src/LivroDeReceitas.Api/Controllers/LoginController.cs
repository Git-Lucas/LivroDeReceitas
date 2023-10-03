using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Domain.Login.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController([FromServices] ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseLogin), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] RequestLogin requestLogin)
    {
        var result = await _loginService.LoginAsync(requestLogin);

        return Ok(result);
    }
}
