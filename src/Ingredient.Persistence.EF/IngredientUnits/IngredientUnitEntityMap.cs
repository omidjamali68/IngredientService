using Ingredient.Domain.IngredientUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingredient.Persistence.EF.IngredientUnits
{
    internal class IngredientUnitEntityMap : IEntityTypeConfiguration<IngredientUnit>
    {
        public void Configure(EntityTypeBuilder<IngredientUnit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Ingredient)
                .WithMany(x => x.IngredientUnits)
                .HasForeignKey(x => x.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Unit)
                .WithMany(x => x.IngredientUnits)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
