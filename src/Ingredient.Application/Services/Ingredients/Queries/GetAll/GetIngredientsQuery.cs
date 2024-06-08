using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Queries.GetAll
{
    public sealed record GetIngredientsQuery(string? SearchKey, int Page) : IQuery<GetIngredientsResponse>;
}
