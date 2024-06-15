using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Units.Commands.Update
{
    public sealed record UpdateUnitCommand(int Id, string Title) : ICommand;
}
