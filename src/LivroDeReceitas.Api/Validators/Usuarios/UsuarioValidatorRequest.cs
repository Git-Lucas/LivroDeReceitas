using FluentValidation;
using FluentValidation.Results;
using LivroDeReceitas.Api.DTOs.Usuarios;
using System.Text.RegularExpressions;

namespace LivroDeReceitas.Api.Validators.Usuarios;

public class UsuarioValidatorRequest : AbstractValidator<CreateUsuarioRequest> 
{
    public UsuarioValidatorRequest()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo é obrigatório");
        RuleFor(x => x.Email).NotEmpty().WithMessage("O campo é obrigatório");
        RuleFor(x => x.Senha).NotEmpty().WithMessage("O campo é obrigatório");
        RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo é obrigatório");
        When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail inválido");
        });
        When(x => !string.IsNullOrWhiteSpace(x.Senha), () =>
        {
            RuleFor(x => x.Senha.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve ter no mínimo 6 caracteres");
        });
        When(x => !string.IsNullOrWhiteSpace(x.Telefone), () =>
        {
            RuleFor(x => x.Telefone).Custom((Telefone, contexto) =>
            {
                var isMatch = Regex.IsMatch(Telefone, "[0-9]{2} [1-9]{1}[0-9]{4}-[0-9]{4}");

                if (!isMatch)
                {
                    contexto.AddFailure(new ValidationFailure(nameof(Telefone), "Telefone inválido"));
                }
            });
        });
    }
}
