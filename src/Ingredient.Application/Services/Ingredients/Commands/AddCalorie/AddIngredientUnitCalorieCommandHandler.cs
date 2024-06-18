using Ingredient.Application.Interfaces;
using Ingredient.Common;
using Ingredient.Domain;
using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Commands.AddCalorie
{
    internal class AddIngredientUnitCalorieCommandHandler : ICommandHandler<AddIngredientUnitCalorieCommand>
    {
        private readonly IIngredientUnitRepository _ingredientUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddIngredientUnitCalorieCommandHandler(IIngredientUnitRepository ingredientUnitRepository, IUnitOfWork unitOfWork)
        {
            _ingredientUnitRepository = ingredientUnitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddIngredientUnitCalorieCommand request, CancellationToken cancellationToken)
        {
            var ingrUnit = await _ingredientUnitRepository.FindById(request.ingredientUnitId);
            if (ingrUnit == null)
                return IngredientUnitErrors.NotExist;

            request.dto.Calories.ForEach(x => ingrUnit.SetCalorie(x.Id, x.Value));

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
