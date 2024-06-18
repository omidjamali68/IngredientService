using Ingredient.Application.Interfaces;
using Ingredient.Domain.IngredientUnits;

namespace Ingredient.Application.Services.Ingredients
{
    public interface IIngredientUnitRepository : IRepository
    {
        Task<IngredientUnit?> FindById(int id);
    }
}
