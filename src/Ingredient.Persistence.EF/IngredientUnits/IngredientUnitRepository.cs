using Ingredient.Application.Services.Ingredients;
using Ingredient.Domain.IngredientUnits;

namespace Ingredient.Persistence.EF.IngredientUnits
{
    internal class IngredientUnitRepository : IIngredientUnitRepository
    {
        private readonly AppDbContext _context;

        public IngredientUnitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IngredientUnit?> FindById(int id)
        {
            return await _context.IngredientUnits.FindAsync(id);
        }
    }
}
