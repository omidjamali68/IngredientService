using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Commands.Add
{
    public sealed record AddIngredientCommand(string Title, List<int> units) : ICommand<Guid>;
}
