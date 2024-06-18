using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Calories.Commands.Update
{
    public sealed record UpdateCalorieCommand(int id, UpdateCalorieDto dto) : ICommand;
}
