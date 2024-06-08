using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Units.Commands.Add
{
    public sealed record AddUnitCommand(string Title) : ICommand<int>;
}
