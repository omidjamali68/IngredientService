using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Units;
using Ingredient.Domain;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Commands.Add
{
    internal class AddIngredientCommandHandler : ICommandHandler<AddIngredientCommand, Guid>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public AddIngredientCommandHandler(
            IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public async Task<Result<Guid>> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {                        
            var ingredientResult = Domain.Ingredients.Ingredient.Create(request.Title);

            if (ingredientResult.IsFailure)
               return Result.Failure<Guid>(ingredientResult.Error);

            if (!await _unitRepository.IsExist(request.units))
                return Result.Failure<Guid>(Error.NullValue);

            var ingredient = ingredientResult.Value!;

            ingredient.SetUnitsById(request.units);            

            await _ingredientRepository.Add(ingredient);
            await _unitOfWork.SaveChangeAsync();

            return Result.Success(ingredient.Id);
        }
    }
}
