using Ingredient.Application.Interfaces;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Units.Queries.GetAll
{
    public class GetUnitsQueryHandler : IQueryHandler<GetUnitsQuery, GetUnitsResponse>
    {
        private readonly IUnitRepository unitRepository;

        public GetUnitsQueryHandler(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public async Task<Result<GetUnitsResponse>> Handle(
            GetUnitsQuery request, CancellationToken cancellationToken)
        {
            return await unitRepository.GetAll(request.SearchKey, request.Page);
        }
    }
}
