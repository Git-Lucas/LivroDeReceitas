using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Domain.Login.DTOs;
using LivroDeReceitas.Domain.Usuarios;

namespace LivroDeReceitas.Api.Services;

public class LoginService : ILoginService
{
    private readonly IUsuarioData _usuarioData;
    private readonly ITokenService _tokenService;
    private readonly IPasswordEncryptor _passwordEncryptor;

    public LoginService(IUsuarioData usuarioData, ITokenService tokenService, IPasswordEncryptor passwordEncryptor)
    {
        _usuarioData = usuarioData;
        _tokenService = tokenService;
        _passwordEncryptor = passwordEncryptor;
    }

    public async Task<ResponseLogin> LoginAsync(RequestLogin requestLogin)
    {
        string encryptedSenha = _passwordEncryptor.Encrypt(requestLogin.SenhaUsuario);
        Usuario usuario = await _usuarioData.GetByEmailESenhaAsync(requestLogin.EmailUsuario, encryptedSenha);

        return new ResponseLogin()
        {
            NomeUsuario = usuario.Nome,
            TokenUsuario = _tokenService.GenerateToken(usuario.Email)
        };
    }
}
