﻿using LivroDeReceitas.Domain.Base;

namespace LivroDeReceitas.Domain.Entities;

public class Usuario : BaseEntity
{
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
}
