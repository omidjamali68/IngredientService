using Ingredient.Application.Interfaces;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Queries.GetAll
{
    internal class GetIngredientQueryHandler : IQueryHandler<GetIngredientsQuery, GetIngredientsResponse>
    {
        private readonly IIngredientRepository  _repository;

        public GetIngredientQueryHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetIngredientsResponse>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(request.SearchKey, request.Page);
        }
    }
}
