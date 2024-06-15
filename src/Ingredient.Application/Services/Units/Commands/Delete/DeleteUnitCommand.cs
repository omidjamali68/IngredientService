using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Units.Commands.Delete
{
    public sealed record DeleteUnitCommand(int Id) : ICommand;
}
