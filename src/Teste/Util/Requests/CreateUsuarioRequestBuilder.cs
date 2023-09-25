using Bogus;
using LivroDeReceitas.Domain.DTOs.Usuarios;

namespace Util.Requests;

public class CreateUsuarioRequestBuilder
{
    public static CreateUsuarioRequest Build(int lenghtSenha = 10)
    {
        return new Faker<CreateUsuarioRequest>()
            .RuleFor(x => x.Nome, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Senha, f => f.Internet.Password(lenghtSenha))
            .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumber($"## {f.Random.Int(1,9)}####-####"));
    }
}
