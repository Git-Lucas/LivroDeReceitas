﻿using FluentValidation;
using FluentValidation.Results;
using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Domain.Usuarios.DTOs;
using System.Text.RegularExpressions;

namespace LivroDeReceitas.Infrastructure.Validators.Usuarios;

public class UsuarioValidatorRequest : AbstractValidator<CreateUsuarioRequest>
{
    public UsuarioValidatorRequest(IUsuarioData usuarioData)
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage(x => $"O campo '{nameof(x.Nome)}' é obrigatório");
        RuleFor(x => x.Email).NotEmpty().WithMessage(x => $"O campo '{nameof(x.Email)}' é obrigatório");
        RuleFor(x => x.Senha).NotEmpty().WithMessage(x => $"O campo '{nameof(x.Senha)}' é obrigatório");
        RuleFor(x => x.Telefone).NotEmpty().WithMessage(x => $"O campo '{nameof(x.Telefone)}' é obrigatório");
        When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail inválido");
            RuleFor(x => x.Email).MustAsync(async (email, cancellation) =>
            {
                bool exists = await usuarioData.ExistsByEmail(email);

                if (exists)
                {
                    return false;
                }
                return true;
            }).WithMessage("O e-mail informado já está cadastrado");
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
