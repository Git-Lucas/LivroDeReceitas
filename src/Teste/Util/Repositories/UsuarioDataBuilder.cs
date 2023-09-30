using LivroDeReceitas.Domain.Usuarios;
using Moq;

namespace Util.Repositories;

public class UsuarioDataBuilder
{
    private static UsuarioDataBuilder? _instance;
    private readonly Mock<IUsuarioData> _usuarioData;

    public UsuarioDataBuilder()
    {
        if (_usuarioData is null)
        {
            _usuarioData = new Mock<IUsuarioData>();
        }
    }

    public static UsuarioDataBuilder Instance()
    {
        _instance = new UsuarioDataBuilder();
        return _instance;
    }

    public UsuarioDataBuilder ExistsByEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            _usuarioData.Setup(x => x.ExistsByEmail(email)).ReturnsAsync(true);
        }

        return this;
    }

    public IUsuarioData Build()
    {
        return _usuarioData.Object;
    }
}
