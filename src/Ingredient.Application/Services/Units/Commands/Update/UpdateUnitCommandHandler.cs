using Ingredient.Application.Interfaces;
using Ingredient.Domain;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Units.Commands.Update
{
    internal class UpdateUnitCommandHandler : ICommandHandler<UpdateUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitRepository.FindById(request.Id);
            if (unit == null) 
                return Error.NullValue;

            var result = unit.Update(request.Title);

            if (result.IsFailure)
                return result.Error;

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
