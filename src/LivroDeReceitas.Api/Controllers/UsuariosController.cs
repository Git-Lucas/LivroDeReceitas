using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Api.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers;

[Route("")]
[ApiController]
public class UsuariosController : ControllerBase
{
    public UsuariosController()
    {

    }

    [HttpGet("")]
    public async Task<IActionResult> GetAsync()
    {
        var usuarioService = new UsuarioService();
        await usuarioService.CreateUsuarioAsync(new CreateUsuarioRequest
        {
            Email = "",
            Nome = "",
            Senha = "",
            Telefone = ""
        });

        return Ok();
    }
}
