using Ingredient.Domain.SeedWork;
using Ingredient.Domain.ShareKernel.ValueObjects;

namespace Ingredient.Domain.Calories
{
    public class Calorie : Entity<int>
    {
        public Title Title { get; internal set; }

        private Calorie(Title title)
        {
            Title = title;
        }

        public static Result<Calorie> Create(string title)
        {
            var titleResult = Title.Create(title);

            if (titleResult.IsFailure)
                return Result.Failure<Calorie>(titleResult.Error);

            return new Calorie(titleResult.Value!);
        }
    }
}
