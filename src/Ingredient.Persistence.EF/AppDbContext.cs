using Ingredient.Domain.Calories;
using Ingredient.Domain.IngredientUnits;
using Ingredient.Domain.Units;
using Microsoft.EntityFrameworkCore;

namespace Ingredient.Persistence.EF
{
    public class AppDbContext : DbContext
    {        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Domain.Ingredients.Ingredient> Ingredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<IngredientUnit> IngredientUnits { get; set; }
        public DbSet<Calorie> Calories { get; set; }
        public DbSet<IngredientUnitCalorie> IngredientUnitCalories { get; set; }
    }
}
