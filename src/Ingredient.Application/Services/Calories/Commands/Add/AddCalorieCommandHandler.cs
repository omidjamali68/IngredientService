using Ingredient.Application.Interfaces;
using Ingredient.Domain;
using Ingredient.Domain.Calories;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Calories.Commands.Add
{
    internal class AddCalorieCommandHandler : ICommandHandler<AddCalorieCommand, int>
    {
        private readonly ICalorieRepository _calorieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCalorieCommandHandler(ICalorieRepository calorieRepository, IUnitOfWork unitOfWork)
        {
            _calorieRepository = calorieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(AddCalorieCommand request, CancellationToken cancellationToken)
        {
            var calorie = Calorie.Create(request.title);

            if (calorie.IsFailure)
                return Result.Failure<int>(calorie.Error);

            await _calorieRepository.Add(calorie.Value!);

            await _unitOfWork.SaveChangeAsync();

            return calorie.Value!.Id;
        }
    }
}
