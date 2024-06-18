using Ingredient.Domain.SeedWork;
using Ingredient.Resource;

namespace Ingredient.Domain.Calories
{
    public class CalorieErrors : Error
    {
        public CalorieErrors(string code, string message) : base(code, message)
        {
        }

        public static Error NotExist => Create("Calorie.NotExist", string.Format(Validation.NotExist, DataDictionary.Calorie));
    }
}
