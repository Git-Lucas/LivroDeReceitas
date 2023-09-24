using LivroDeReceitas.Api.Services.Usuarios;

namespace Util.Encryptor;

public class PasswordEncryptorBuilder
{
    public static PasswordEncryptor Instance()
    {
        return new PasswordEncryptor();
    }
}
