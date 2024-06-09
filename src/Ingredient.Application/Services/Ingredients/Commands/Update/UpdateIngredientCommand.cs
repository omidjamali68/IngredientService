using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Commands.Update
{
    public sealed record UpdateIngredientCommand(Guid ID, string title, List<int> units) : ICommand;
}
