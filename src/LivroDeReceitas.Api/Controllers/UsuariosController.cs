﻿using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Domain.Usuarios.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController([FromServices] IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateUsuarioResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUsuarioAsync([FromBody] CreateUsuarioRequest request)
    {
        CreateUsuarioResponse response = await _usuarioService.CreateUsuarioAsync(request);

        return Created(string.Empty, response);
    }
}
