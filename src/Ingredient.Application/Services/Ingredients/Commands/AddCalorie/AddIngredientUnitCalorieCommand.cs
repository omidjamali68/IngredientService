using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Ingredients.Commands.AddCalorie
{
    public sealed record AddIngredientUnitCalorieCommand(int ingredientUnitId, AddColorieDto dto) : ICommand;
}
