namespace LivroDeReceitas.Domain.Exceptions
{
    public class RepositoryErrors : BaseException
    {
        public string MessageError { get; private set; }

        public RepositoryErrors(string messageError)
        {
            MessageError = messageError;
        }
    }
}
