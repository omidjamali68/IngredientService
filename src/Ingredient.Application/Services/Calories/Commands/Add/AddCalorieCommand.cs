using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Calories.Commands.Add
{
    public sealed record AddCalorieCommand(string title) : ICommand<int>;
}
