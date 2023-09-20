namespace LivroDeReceitas.Api.Exceptions
{
    public class ValidatorErrors : BaseException
    {
        public List<string> MessageErrors { get; private set; }

        public ValidatorErrors(List<string> messageErrors)
        {
            MessageErrors = messageErrors;
        }
    }
}
