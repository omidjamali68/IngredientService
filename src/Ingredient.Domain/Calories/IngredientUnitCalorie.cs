using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Domain.Calories
{
    public class IngredientUnitCalorie : Entity
    {
        public int CalorieId { get; internal set; }
        public Calorie Calorie { get; internal set; }
        public int IngredientUnitId { get; internal set; }
        public IngredientUnit IngredientUnit { get; internal set; }
        
        private IngredientUnitCalorie()
        {            
        }

        private IngredientUnitCalorie(IngredientUnit ingredientUnit, Calorie calorie)
        {
            this.Calorie = calorie;
            this.IngredientUnit = ingredientUnit;
        }

        public static IngredientUnitCalorie Create(Calorie calorie, IngredientUnit ingredientUnit)
        {
            return new IngredientUnitCalorie(ingredientUnit, calorie);
        }
    }
}
