using Ingredient.Domain.SeedWork;
using Ingredient.Resource;

namespace Ingredient.Domain.IngredientUnits
{
    public class IngredientUnitErrors : Error
    {
        public IngredientUnitErrors(string code, string message) : base(code, message)
        {
        }

        public static Result NotExist => Create("IngredientUnit.NotExist", string.Format(Validation.NotExist, DataDictionary.IngredientUnit));
    }
}
