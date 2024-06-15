using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Commands.Delete
{
    public sealed record DeleteIngredientCommand(Guid Id) : ICommand;    
}
