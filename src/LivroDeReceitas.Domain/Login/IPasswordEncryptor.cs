namespace LivroDeReceitas.Domain.Login;

public interface IPasswordEncryptor
{
    string Encrypt(string senha);
}
