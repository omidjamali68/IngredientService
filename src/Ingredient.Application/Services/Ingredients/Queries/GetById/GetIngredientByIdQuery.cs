using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Queries.GetById
{
    public sealed record GetIngredientByIdQuery(Guid ID) : IQuery<GetIngredientByIdDto>;   
}
