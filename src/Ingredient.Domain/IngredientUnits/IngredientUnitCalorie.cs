using Ingredient.Domain.Calories;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Domain.IngredientUnits
{
    public class IngredientUnitCalorie : Entity
    {
        public int CalorieId { get; internal set; }
        public Calorie Calorie { get; internal set; }
        public int IngredientUnitId { get; internal set; }
        public IngredientUnit IngredientUnit { get; internal set; }
        public short Value { get; internal set; }

        private IngredientUnitCalorie()
        {
        }

        private IngredientUnitCalorie(IngredientUnit ingredientUnit, Calorie calorie)
        {
            Calorie = calorie;
            IngredientUnit = ingredientUnit;
        }

        public static IngredientUnitCalorie Create(Calorie calorie, IngredientUnit ingredientUnit)
        {
            return new IngredientUnitCalorie(ingredientUnit, calorie);
        }
    }
}
