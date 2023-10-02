using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Infrastructure.Services.Usuarios;

namespace Util.Token;

public class TokenServiceBuilder
{
    public static ITokenService Instance()
    {
        return new TokenService("VWRaW2s+OCQ8ZF8kYn5BRi83YTRgZihLYUhbM107Y1R4OXMrI8KjVENXYCYyPl9xQDZE");
    }
}
