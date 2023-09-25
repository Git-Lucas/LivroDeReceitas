using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivroDeReceitas.Infrastructure.Services.Usuarios;

public class TokenService
{
    private readonly string _key;
    private readonly byte[] _keyInBytes;

    public TokenService(string key)
    {
        _key = key;
        _keyInBytes = Encoding.ASCII.GetBytes(_key);
    }

    public string GenerateToken(string emailUsuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, emailUsuario)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_keyInBytes), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public void ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(_keyInBytes),
            ClockSkew = new TimeSpan(0)
        };

        tokenHandler.ValidateToken(token, validationParameters, out _);
    }
}
