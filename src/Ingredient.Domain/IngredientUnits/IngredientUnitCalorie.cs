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

        private IngredientUnitCalorie(IngredientUnit ingredientUnit, Calorie calorie, short value)
        {
            Calorie = calorie;
            IngredientUnit = ingredientUnit;
        }

        private IngredientUnitCalorie(IngredientUnit ingredientUnit, int calorieId)
        {
            CalorieId = calorieId;
            IngredientUnit = ingredientUnit;
        }

        public IngredientUnitCalorie(IngredientUnit ingredientUnit, int colorieId, short value)
        {
            IngredientUnit = ingredientUnit;
            CalorieId = colorieId;
            Value = value;
        }

        public static Result<IngredientUnitCalorie> Create(Calorie calorie, IngredientUnit ingredientUnit, short value)
        {
            return new IngredientUnitCalorie(ingredientUnit, calorie, value);
        }

        public static Result<IngredientUnitCalorie> Create(IngredientUnit ingredientUnit, int colorieId)
        {
            return new IngredientUnitCalorie(ingredientUnit, colorieId);
        }

        public static Result<IngredientUnitCalorie> Create(IngredientUnit ingredientUnit, int calorieId, short value)
        {
            return new IngredientUnitCalorie(ingredientUnit, calorieId, value);
        }
    }
}
