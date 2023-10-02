using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Infrastructure.Services.Usuarios;

namespace Util.Encryptor;

public class PasswordEncryptorBuilder
{
    public static IPasswordEncryptor Instance()
    {
        return new PasswordEncryptor();
    }
}
