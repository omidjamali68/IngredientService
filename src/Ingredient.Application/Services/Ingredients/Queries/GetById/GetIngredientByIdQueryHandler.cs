using Ingredient.Application.Interfaces;
using Ingredient.Domain.Ingredients;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Queries.GetById
{
    internal class GetIngredientByIdQueryHandler : IQueryHandler<GetIngredientByIdQuery, GetIngredientByIdDto>
    {
        private readonly IIngredientRepository _repository;

        public GetIngredientByIdQueryHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetIngredientByIdDto>> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.ID);

            if (result is null)
            {
                return Result.Failure<GetIngredientByIdDto>(IngredientErrors.NotExist.Error);
            }            

            return result;
        }
    }
}
