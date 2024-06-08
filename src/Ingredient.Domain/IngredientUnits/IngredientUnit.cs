using Ingredient.Domain.SeedWork;
using Ingredient.Domain.Units;

namespace Ingredient.Domain.IngredientUnits
{
    public class IngredientUnit : Entity<int>
    {
        public Guid IngredientId { get; private set; }
        public Ingredients.Ingredient Ingredient { get; private set; }
        public int UnitId { get; private set; }
        public Unit Unit { get; private set; }

        private IngredientUnit() { }

        private IngredientUnit(Ingredients.Ingredient ingredient, Unit unit)
        {
            this.Ingredient = ingredient;
            this.Unit = unit;
        }

        public static Result<IngredientUnit> Create(Ingredients.Ingredient ingredient, Unit unit)
        {
            return new IngredientUnit(ingredient, unit);
        }

    }
}
