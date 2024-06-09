using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Units;
using Ingredient.Domain;
using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Commands.Update
{
    internal class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
    {
        private readonly IIngredientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public UpdateIngredientCommandHandler(
            IIngredientRepository repository, IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public async Task<Result> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _repository.FindById(request.ID);

            if (ingredient == null) 
                return Result.Failure<bool>(Error.NullValue);

            var ingredientUnits = new HashSet<IngredientUnit>();
            foreach (var item in request.units)
            {
                var unit = await _unitRepository.FindById(item);

                if (unit is null)
                    return Result.Failure<Guid>(Error.NullValue);

                ingredientUnits.Add(IngredientUnit.Create(ingredient, unit).Value);
            }
            ingredient.SetUnits(ingredientUnits);

            var result = ingredient.Update(request.title);

            if (result.IsFailure)
                return result;

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
