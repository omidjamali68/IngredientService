using Ingredient.Domain.SeedWork;
using Ingredient.Resource;

namespace Ingredient.Domain.Ingredients
{
    public class IngredientErrors : Error
    {
        public IngredientErrors(string code, string message) : base(code, message)
        {

        }

        public static Result NotExist => Create("Ingredient.NotExist", string.Format(Validation.NotExist, DataDictionary.Ingredient));

        public static Result UnitNotFound => Create("Ingredient.UnitNotFound", string.Format(Validation.NotExist, DataDictionary.Unit));
    }
}
