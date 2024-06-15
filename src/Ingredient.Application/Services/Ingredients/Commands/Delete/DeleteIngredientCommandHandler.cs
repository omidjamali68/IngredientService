using Ingredient.Application.Interfaces;
using Ingredient.Domain;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Commands.Delete
{
    internal class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand>
    {
        private readonly IIngredientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIngredientCommandHandler(IIngredientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _repository.FindById(request.Id);
            if (ingredient == null)
                return Error.NullValue;

            _repository.Delete(ingredient);

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
