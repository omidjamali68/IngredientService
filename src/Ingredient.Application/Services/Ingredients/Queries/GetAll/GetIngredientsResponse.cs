using Ingredient.Application.Common.Dto;

namespace Ingredient.Application.Services.Ingredients.Queries.GetAll
{
    public record GetIngredientsResponse : GetListResponse<GetIngredientsDto>;
}