using Ingredient.Application.Common.Dto;
using Ingredient.Application.Interfaces;

namespace Ingredient.Application.Services.Calories.Queries.GetAll
{
    public sealed record GetCaloriesQuery(string? SearchKey, int Page) : IQuery<GetCaloriesResponse>;
}
