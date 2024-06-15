using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;
using Ingredient.Domain.ShareKernel.ValueObjects;

namespace Ingredient.Domain.Units
{
    public class Unit : Entity<int>
    {
        public Title Title { get; private set; }
        public HashSet<IngredientUnit> IngredientUnits { get; set; }

        private Unit()
        {            
        }

        private Unit(Title title)
        {            
            this.Title = title;
            IngredientUnits = new HashSet<IngredientUnit>();
        }

        public static Result<Unit> Create(string? title)
        {
            var titleResult = Title.Create(title);

            if (titleResult.IsFailure)
            {
                Result.Failure<Unit>(titleResult.Error);
            }

            return new Unit(titleResult.Value);
        }

        public Result Update(string title)
        {
            var titleResult = Title.Create(title);

            if (titleResult.IsFailure) 
                return titleResult.Error;

            this.Title = titleResult.Value!;

            return Result.Success();
        }
    }
}
