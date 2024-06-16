using Ingredient.Application.Interfaces;
using Ingredient.Domain.Calories;

namespace Ingredient.Application.Services.Calories
{
    public interface ICalorieRepository : IRepository
    {
        Task Add(Calorie calorie);
    }
}
