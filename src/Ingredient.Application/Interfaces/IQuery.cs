using Ingredient.Domain.SeedWork;
using MediatR;

namespace Ingredient.Application.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
