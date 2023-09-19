using FluentValidation;
using LivroDeReceitas.Domain.Interfaces.Data;

namespace LivroDeReceitas.Api.Services;

public abstract class BaseService
{
    protected internal IUnitOfWork _unitOfWork { get; set; }

    public BaseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
