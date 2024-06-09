namespace Ingredient.Application.Services.Ingredients.Commands.Update
{
    public sealed record UpdateIngredientDto(string title, List<int> units);
}
