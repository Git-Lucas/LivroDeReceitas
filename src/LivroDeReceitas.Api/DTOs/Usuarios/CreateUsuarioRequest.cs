﻿namespace LivroDeReceitas.Api.DTOs.Usuarios;

public class CreateUsuarioRequest
{
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required string Senha { get; set; }
}
