using Ingredient.Application.Services.Units;
using Ingredient.Application.Services.Units.Queries.GetAll;
using Ingredient.Common;
using Ingredient.Domain.Units;
using Microsoft.EntityFrameworkCore;

namespace Ingredient.Persistence.EF.Units
{
    public class UnitRepository : IUnitRepository
    {
        private readonly AppDbContext context;

        public UnitRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Unit unit)
        {
            await context.Units.AddAsync(unit);
        }

        public async Task<Unit?> FindById(int id)
        {
            return await context.Units
                .Include(x => x.IngredientUnits)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetUnitsResponse> GetAll(string? searchKey, int page)
        {
            var units = context.Units.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                units = units.Where(x => ((string)x.Title).Contains(searchKey));
            }

            var reult = units.Select(x => new GetUnitsDto
            {
                Id = x.Id,
                Title = x.Title.Value
            });

            var rows = 0;
            var data = await reult.ToPaged(page, 20, out rows).ToListAsync();

            return new GetUnitsResponse
            {
                Rows = rows,
                Data = data
            };
        }

        public async Task<bool> IsExist(List<int> Ids)
        {
            return await context.Units.AnyAsync(x => Ids.Contains(x.Id));
        }
    }
}
