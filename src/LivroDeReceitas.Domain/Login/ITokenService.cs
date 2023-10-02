namespace LivroDeReceitas.Domain.Login;

public interface ITokenService
{
    string GenerateToken(string emailUsuario);
    void ValidateToken(string token);
}
