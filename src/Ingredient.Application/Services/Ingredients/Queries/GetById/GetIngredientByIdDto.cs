namespace Ingredient.Application.Services.Ingredients.Queries.GetById
{
    public sealed record GetIngredientByIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public HashSet<IngredientUnitDto>? Units { get; set; }
    }

    public sealed record IngredientUnitDto(string title, int id);
}
