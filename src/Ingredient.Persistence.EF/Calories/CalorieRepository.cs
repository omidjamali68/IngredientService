using Ingredient.Application.Services.Calories;
using Ingredient.Application.Services.Calories.Queries.GetAll;
using Ingredient.Common;
using Ingredient.Domain.Calories;
using Ingredient.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<Calorie?> FindById(int id)
        {
            return await _context.Calories.FindAsync(id);
        }

        public async Task<Result<GetCaloriesResponse>> GetAll(string? searchKey, int page)
        {
            var calories = _context.Calories.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
                calories = calories.Where(x => ((string)x.Title).Contains(searchKey));

            var result = calories.Select(x => new GetCaloriesDto
            {
                Id = x.Id,
                Title = x.Title.Value
            });

            var rows = 0;
            var data = await result.ToPaged(page, 20, out rows).ToListAsync();

            return new GetCaloriesResponse
            {
                Data = data,
                Rows = rows
            };
        }
    }
}
