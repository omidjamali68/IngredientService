using Ingredient.Domain.SeedWork;
using MediatR;

namespace Ingredient.Application.Interfaces
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
