namespace LivroDeReceitas.Domain.Login.DTOs;

public class ResponseLogin
{
    public required string TokenUsuario { get; set; }
    public required string NomeUsuario { get; set; }
}
