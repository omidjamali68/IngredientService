namespace Ingredient.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {        
        
        Task Delete(T entity);        
    }
}
