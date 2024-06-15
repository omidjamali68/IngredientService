using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Units;
using Ingredient.Domain;
using Ingredient.Domain.Ingredients;
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
                return IngredientErrors.NotExist;

            if (!await _unitRepository.IsExist(request.units))
                return IngredientErrors.UnitNotFound;
            
            ingredient.SetUnitsById(request.units);            

            var result = ingredient.Update(request.title);

            if (result.IsFailure)
                return result;

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
