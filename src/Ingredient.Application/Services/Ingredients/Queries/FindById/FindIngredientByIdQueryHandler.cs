using Ingredient.Application.Interfaces;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Ingredients.Queries.FindById
{
    internal class FindIngredientByIdQueryHandler : IQueryHandler<FindIngredientByIdQuery, FindIngredientByIdDto>
    {
        private readonly IIngredientRepository _repository;

        public FindIngredientByIdQueryHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<FindIngredientByIdDto>> Handle(FindIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindById(request.ID);

            if (result == null)
            {
                return Result.Failure<FindIngredientByIdDto>(Error.NullValue);
            }

            return Result.Success(new FindIngredientByIdDto { Id = result.Id, Title= result.Title.Value});
        }
    }
}
