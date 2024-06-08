using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Queries.FindById
{
    public sealed record FindIngredientByIdQuery(Guid ID) : IQuery<FindIngredientByIdDto>;   
}
