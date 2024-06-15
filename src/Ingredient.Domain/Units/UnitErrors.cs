using Ingredient.Domain.SeedWork;
using Ingredient.Resource;

namespace Ingredient.Domain.Units
{
    public class UnitErrors : Error
    {
        public UnitErrors(string code, string message) : base(code, message)
        {
        }

        public static Error UsedBy => Create("Unit.UsedBy", string.Format(Validation.IsUsedBy, DataDictionary.Unit));
        public static Error NotExist => Create("Unit.NotExist", string.Format(Validation.NotExist, DataDictionary.Unit));
    }
}
