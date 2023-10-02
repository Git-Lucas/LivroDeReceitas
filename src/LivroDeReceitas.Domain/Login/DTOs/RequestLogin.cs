namespace LivroDeReceitas.Domain.Login.DTOs;

public class RequestLogin
{
    public required string EmailUsuario { get; set; }
    public required string SenhaUsuario { get; set; }
}
