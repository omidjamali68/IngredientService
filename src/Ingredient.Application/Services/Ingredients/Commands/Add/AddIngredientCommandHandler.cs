using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Units;
using Ingredient.Domain;
using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Commands.Add
{
    internal class AddIngredientCommandHandler : ICommandHandler<AddIngredientCommand, Guid>
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUnitRepository unitRepository;

        public AddIngredientCommandHandler(
            IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            this.ingredientRepository = ingredientRepository;
            this.unitOfWork = unitOfWork;
            this.unitRepository = unitRepository;
        }

        public async Task<Result<Guid>> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = Domain.Ingredients.Ingredient.Create(request.Title);

            if (ingredient.IsFailure)
               return Result.Failure<Guid>(ingredient.Error);

            var ingredientUnits = new HashSet<IngredientUnit>();
            foreach(var item in request.units)
            {
                var unit = await unitRepository.FindById(item);

                if (unit is null)                
                    return Result.Failure<Guid>(Error.NullValue);                

                ingredientUnits.Add(IngredientUnit.Create(ingredient.Value, unit).Value);                
            }

            ingredient.Value.SetUnits(ingredientUnits);

            await ingredientRepository.Add(ingredient.Value);
            await unitOfWork.SaveChangeAsync();

            return Result.Success(ingredient.Value.Id);
        }
    }
}
