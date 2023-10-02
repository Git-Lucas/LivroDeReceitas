namespace LivroDeReceitas.Domain.Exceptions;

public class InvalidLoginError : RepositoryErrors
{
    public InvalidLoginError(string messageError) : base(messageError)
    {
    }
}
