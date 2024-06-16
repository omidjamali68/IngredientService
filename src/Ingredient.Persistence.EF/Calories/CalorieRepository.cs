using Ingredient.Application.Services.Calories;
using Ingredient.Domain.Calories;

namespace Ingredient.Persistence.EF.Calories
{
    internal class CalorieRepository : ICalorieRepository
    {
        private readonly AppDbContext _context;

        public CalorieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Calorie calorie)
        {
            await _context.Calories.AddAsync(calorie);
        }
    }
}
