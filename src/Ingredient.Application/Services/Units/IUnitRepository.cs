using Ingredient.Application.Interfaces;
using Ingredient.Application.Services.Units.Queries.GetAll;
using Ingredient.Domain.Units;

namespace Ingredient.Application.Services.Units
{
    public interface IUnitRepository : IRepository<Unit>
    {
        Task Add(Unit unit);
        Task<Unit?> FindById(int id);
        Task<GetUnitsResponse> GetAll(string? searchKey, int page);
    }
}
