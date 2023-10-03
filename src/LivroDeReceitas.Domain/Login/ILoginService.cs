using LivroDeReceitas.Domain.Login.DTOs;

namespace LivroDeReceitas.Domain.Login;

public interface ILoginService
{
    Task<ResponseLogin> LoginAsync(RequestLogin requestLogin);
}
