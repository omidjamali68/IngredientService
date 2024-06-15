using Ingredient.Application.Interfaces;
using Ingredient.Domain;
using Ingredient.Domain.SeedWork;
using Ingredient.Domain.Units;

namespace Ingredient.Application.Services.Units.Commands.Add
{       
    public class AddUnitCommandHandler : ICommandHandler<AddUnitCommand, int>
    {
        private readonly IUnitRepository unitRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            this.unitRepository = unitRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(AddUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = Unit.Create(request.Title);

            if (unit.IsFailure)
                return Result.Failure<int>(unit.Error);

            await unitRepository.Add(unit.Value!);
            await unitOfWork.SaveChangeAsync();

            return Result.Success(unit.Value!.Id);
        }
    }
}
