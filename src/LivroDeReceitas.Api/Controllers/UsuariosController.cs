using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Api.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers;

[Route("")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController([FromServices] IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _usuarioService.CreateUsuarioAsync(new CreateUsuarioRequest
        {
            Email = "lucas@gmail.com",
            Nome = "Lucas",
            Senha = "123456",
            Telefone = "31 98549-5824"
        });

        return Ok(response);
    }
}
