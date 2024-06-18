using Ingredient.Domain.Calories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingredient.Persistence.EF.Calories
{
    internal class IngredientUnitCalorieEntityMap : IEntityTypeConfiguration<IngredientUnitCalorie>
    {
        public void Configure(EntityTypeBuilder<IngredientUnitCalorie> builder)
        {
            builder.ToTable("IngredientUnitCalories");

            builder.HasKey(x => new {x.CalorieId, x.IngredientUnitId});

            builder.HasOne(x => x.Calorie)
                .WithMany(x => x.IngredientUnitCalories)
                .HasForeignKey(x => x.CalorieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.IngredientUnit)
                .WithMany(x => x.IngredientUnitCalories)
                .HasForeignKey(x => x.IngredientUnitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
