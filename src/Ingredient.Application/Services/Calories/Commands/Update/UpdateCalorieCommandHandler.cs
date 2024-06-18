using Ingredient.Application.Interfaces;
using Ingredient.Domain.Calories;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Calories.Commands.Update
{
    internal class UpdateCalorieCommandHandler : ICommandHandler<UpdateCalorieCommand>
    {
        private readonly ICalorieRepository _calorieRepository;

        public UpdateCalorieCommandHandler(ICalorieRepository calorieRepository)
        {
            _calorieRepository = calorieRepository;
        }

        public async Task<Result> Handle(UpdateCalorieCommand request, CancellationToken cancellationToken)
        {
            var calorie = await _calorieRepository.FindById(request.id);
            if (calorie == null)
                return CalorieErrors.NotExist;

            var result = calorie.Update(request.dto.Title);
            if (result.IsFailure)
                return result.Error;

            return result;
        }
    }
}
