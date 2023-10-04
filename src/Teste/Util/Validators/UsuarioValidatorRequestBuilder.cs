using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Infrastructure.Validators.Usuarios;
using Util.Repositories;

namespace Util.Validators;

public class UsuarioValidatorRequestBuilder
{
    public static UsuarioValidatorRequest Instance(string email = "")
    {
        IUsuarioData usuarioData = UsuarioDataBuilder.Instance().ExistsByEmail(email).Build();

        return new UsuarioValidatorRequest(usuarioData);
    }
}
