using LivroDeReceitas.Domain.Login.DTOs;

namespace LivroDeReceitas.Domain.Login;

public interface ILoginService
{
    Task<ResponseLogin> Login(RequestLogin requestLogin);
}
