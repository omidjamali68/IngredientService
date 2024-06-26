﻿using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Ingredients.Queries.GetAll;
using Ingredient.Application.Services.Ingredients.Queries.GetById;

namespace Ingredient.Application.Services.Ingredients
{
    public interface IIngredientRepository : IRepository
    {
        Task<GetIngredientsResponse> GetAll(string? searchKey, int page);
        Task Add(Domain.Ingredients.Ingredient ingredient);
        Task<Domain.Ingredients.Ingredient?> FindById(Guid id);
        void Delete(Domain.Ingredients.Ingredient ingredient);
        Task<GetIngredientByIdDto?> GetById(Guid id);
    }
}
