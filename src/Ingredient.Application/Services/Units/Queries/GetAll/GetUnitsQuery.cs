using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Units.Queries.GetAll
{
    public sealed record GetUnitsQuery(string? SearchKey, int Page) : IQuery<GetUnitsResponse>;
}
