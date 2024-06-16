using Ingredient.Application.Interfaces;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Calories.Queries.GetAll
{
    internal class GetCaloriesQueryHandler : IQueryHandler<GetCaloriesQuery, GetCaloriesResponse>
    {
        private readonly ICalorieRepository _calorieRepository;

        public GetCaloriesQueryHandler(ICalorieRepository calorieRepository)
        {
            _calorieRepository = calorieRepository;
        }

        public async Task<Result<GetCaloriesResponse>> Handle(GetCaloriesQuery request, CancellationToken cancellationToken)
        {
            return await _calorieRepository.GetAll(request.SearchKey, request.Page);
        }
    }
}
