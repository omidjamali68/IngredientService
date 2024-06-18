using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Calories.Queries.GetAll;
using Ingredient.Domain.Calories;
using Ingredient.Domain.SeedWork;

namespace Ingredient.Application.Services.Calories
{
    public interface ICalorieRepository : IRepository
    {
        Task Add(Calorie calorie);
        Task<Calorie?> FindById(int id);
        Task<Result<GetCaloriesResponse>> GetAll(string? searchKey, int page);
    }
}
