namespace Ingredient.Application.Services.Ingredients.Commands.AddCalorie
{
    public sealed record AddColorieDto
    {
        public HashSet<CalorieDto> Calories { get; set; }
    }

    public sealed record CalorieDto
    {
        public int Id { get; set; }
        public short Value { get; set; }
    }
}
