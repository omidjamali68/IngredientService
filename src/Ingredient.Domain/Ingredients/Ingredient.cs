using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;
using Ingredient.Domain.ShareKernel.ValueObjects;

namespace Ingredient.Domain.Ingredients
{
    public class Ingredient : Entity<Guid>
    {

        public Title Title { get; private set; }
        public HashSet<IngredientUnit> IngredientUnits { get; private set; }

        private Ingredient()
        {
            IngredientUnits = new HashSet<IngredientUnit>();
        }

        private Ingredient(Title title)
        {
            this.Title = title;
            IngredientUnits = new HashSet<IngredientUnit>();
        }

        public static Result<Ingredient> Create(string? title)
        {
            var titleResult = Title.Create(title);

            if (titleResult.IsFailure)
            {
                return Result.Failure<Ingredient>(titleResult.Error);
            }

            return new Ingredient(titleResult.Value!);
        }

        public void SetUnits(HashSet<IngredientUnit> units)
        {
            IngredientUnits = units;
        }

        public Result SetUnitsById(List<int> units)
        {
            foreach (var item in units)
            {
                var ingrUnit = IngredientUnit.Create(this, item);

                if (ingrUnit.IsFailure)
                    return ingrUnit;

                IngredientUnits.Add(ingrUnit.Value!);
            }

            return Result.Success();
        }

        public Result Update(string title)
        {
            var titleResult = Title.Create(title);

            if (titleResult.IsFailure)
            {
                return titleResult.Error;
            }

            this.Title = titleResult.Value!;
            return Result.Success();
        }
    }
}
