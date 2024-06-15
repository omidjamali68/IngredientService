using Ingredient.Application.Interfaces;
using Ingredient.Domain;
using Ingredient.Domain.SeedWork;
using Ingredient.Domain.Units;

namespace Ingredient.Application.Services.Units.Commands.Delete
{
    internal class DeleteUnitCommandHandler : ICommandHandler<DeleteUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitRepository.FindById(request.Id);

            if (unit == null)
                return UnitErrors.NullValue;

            if (unit.IngredientUnits.Any())
                return UnitErrors.UsedBy;

            _unitRepository.Delete(unit);

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
