namespace Ingredient.Domain.SeedWork
{
    public class Entity
    {

    }

    public class Entity<T> : Entity
    {
        public T Id { get; set; }
    }
}
