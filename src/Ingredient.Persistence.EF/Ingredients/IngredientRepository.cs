using Ingredient.Application.Services.Ingredients;
using Ingredient.Application.Services.Ingredients.Queries.GetAll;
using Ingredient.Application.Services.Units.Queries.GetAll;
using Ingredient.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingredient.Persistence.EF.Ingredients
{
    internal class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext context;

        public IngredientRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }

        public async Task Add(Domain.Ingredients.Ingredient ingredient)
        {
            await context.Ingredients.AddAsync(ingredient);
        }

        public async Task<GetIngredientsResponse> GetAll(string? searchKey, int page)
        {
            var ingredients = context.Ingredients.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                ingredients = ingredients.Where(x => ((string)x.Title).Contains(searchKey));
            }

            var reult = ingredients.Select(x => new GetIngredientsDto
            {
                Id = x.Id,
                Title = x.Title.Value
            });

            var rows = 0;
            var data = await reult.ToPaged(page, 20, out rows).ToListAsync();

            return new GetIngredientsResponse
            {
                Rows = rows,
                Data = data
            };
        }
    }
}
