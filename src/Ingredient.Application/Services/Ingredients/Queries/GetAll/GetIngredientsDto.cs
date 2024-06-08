namespace Ingredient.Application.Services.Ingredients.Queries.GetAll
{
    public record GetIngredientsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}